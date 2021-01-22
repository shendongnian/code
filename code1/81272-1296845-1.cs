    using System;
    using ProtoBuf;
    [ProtoContract]
    [ProtoInclude(2, typeof(Response))]
    [ProtoInclude(3, typeof(Query))]
    class Packet
    {
        [ProtoMember(1)]
        int ID;
    }
    [ProtoContract]
    [ProtoInclude(1, typeof(Response<int>))]
    [ProtoInclude(2, typeof(Response<decimal>))]
    [ProtoInclude(3, typeof(Response<string>))]
    class Response : Packet
    {
    }
    [ProtoContract]
    class Response<T> : Response
    {
        [ProtoMember(2)]
        public T Value;
    
        public override string ToString()
        {
            return typeof(T).Name + ": " + Value;
        }
    }
    static class Program
    {
        static void Main()
        {
            Packet packet = new Response<int> { Value = 123 };
            Packet clone = Serializer.DeepClone<Packet>(packet);
            Console.WriteLine(clone.ToString()); // should be int/123
        }
    }
