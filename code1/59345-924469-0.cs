    using System;
    using System.Collections.Generic;
    using ProtoBuf;
    [ProtoContract]
    [ProtoInclude(10, typeof(DataItem<int>))]
    [ProtoInclude(11, typeof(DataItem<string>))]
    [ProtoInclude(12, typeof(DataItem<DateTime>))]
    [ProtoInclude(13, typeof(DataItem<Foo>))]
    abstract class DataItem {
        public static DataItem<T> Create<T>(T value) {
            return new DataItem<T>(value);
        }
        public object Value {
            get { return ValueImpl; }
            set { ValueImpl = value; }
        }
        protected abstract object ValueImpl {get;set;}
        protected DataItem() { }
    }
    [ProtoContract]
    sealed class DataItem<T> : DataItem {
        public DataItem() { }
        public DataItem(T value) { Value = value; }
        [ProtoMember(1)]
        public new T Value { get; set; }
        protected override object ValueImpl {
            get { return Value; }
            set { Value = (T)value; }
        }
    }
    [ProtoContract]
    public class Foo {
        [ProtoMember(1)]
        public string Bar { get; set; }
        public override string ToString() {
            return "Foo with Bar=" + Bar;
        }
    }
    static class Program {
        static void Main() {
            var items = new List<DataItem>();
            items.Add(DataItem.Create(12345));
            items.Add(DataItem.Create(DateTime.Today));
            items.Add(DataItem.Create("abcde"));
            items.Add(DataItem.Create(new Foo { Bar = "Marc" }));
            items.Add(DataItem.Create(67890));
    
            // serialize and deserialize
            var clone = Serializer.DeepClone(items);
            foreach (DataItem item in clone) {
                Console.WriteLine(item.Value);
            }
        }
    }
