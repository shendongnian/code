        [ProtoContract]
        [ProtoInclude(7, typeof(Class_A))]
        [ProtoInclude(8, typeof(Class_B))]
        public ProtoStub : grid
        {
        }
        [ProtoContract]
        public Class_A : ProtoStub
        {
        }
        [ProtoContract]
        public Class_B : ProtoStub
        {
        }
