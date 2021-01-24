    interface IPopulateable{
        void Populate(BinaryReader);
    }
    class ComplexObject : IPopulateable{
        public int MyInteger {get;private set;}
        public Populate(BinaryReader br){
            MyInteger = br.ReadInt32();
        }
    }
