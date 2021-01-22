    using System;
    using ProtoBuf;
    static class Program
    {
        static void Main()
        {
            var message1 = new SomeMessageWithVariableKey<string>(123456, "abcdef");
            var clone1 = Serializer.DeepClone(message1);
            Console.WriteLine(clone1.Key);
            Console.WriteLine(clone1.SomeOtherValue);
    
            var message2 = new SomeMessageWithVariableKey<int>("abcdef", 123456);
            var clone2 = Serializer.DeepClone(message2);
            Console.WriteLine(clone2.Key);
            Console.WriteLine(clone2.SomeOtherValue);
        }
    }
    
    [ProtoContract]
    [ProtoInclude(1, typeof(ProtoKey<int>))]
    [ProtoInclude(2, typeof(ProtoKey<string>))]
    abstract class ProtoKey
    {
        public static ProtoKey Create(object key)
        {
            if (key == null) return null;
            if (key is string) return new ProtoKey<string> { Value = key };
            if (key is int) return new ProtoKey<int> { Value = key };
            throw new ArgumentException("Unexpected key type: " + key.GetType().Name);
        }
    
        public abstract object Value { get; protected set;}
        public override string ToString()
        {
            return Convert.ToString(Value);
        }
        public override bool Equals(object obj)
        {
            ProtoKey other = obj as ProtoKey;
            if (other == null) return false;
            return object.Equals(Value, other.Value);
        }
        public override int GetHashCode()
        {
            object val = Value;
            return val == null ? 0 : val.GetHashCode();
        }
    }
    [ProtoContract]
    sealed class ProtoKey<T> : ProtoKey
    {
        [ProtoMember(1)]
        public T TypedValue { get; set; }
        public override object Value
        {
            get { return TypedValue; }
            protected set { TypedValue = (T)value; }
        }
    }
    
    [ProtoContract]
    public class SomeMessageWithVariableKey<T>
    {
        private SomeMessageWithVariableKey() { }
        public SomeMessageWithVariableKey(object key, T someOtherValue) {
            Key = key;
            SomeOtherValue = someOtherValue;
        }
        public object Key { get; private set; }
    
        [ProtoMember(1)]
        private ProtoKey SerializationKey
        {
            get { return ProtoKey.Create(Key); }
            set { Key = value == null ? null : value.Value; }
        }
        [ProtoMember(2)]
        public T SomeOtherValue { get; set; }
    }
