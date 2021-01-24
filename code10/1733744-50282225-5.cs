        [ProtoContract]
        [ProtoInclude(7, typeof(Class_A))]
        [ProtoInclude(8, typeof(Class_B))]
        public class ProtoStub : grid
        {
        }
        [ProtoContract]
        public class Class_A : ProtoStub
        {
        }
        [ProtoContract]
        public class Class_B : ProtoStub
        {
        }
