    class MyBaseClass
    {
        public enum ClassTypeEnum { A, B }
        public ClassTypeEnum ClassType { get; protected set; }
    }
    class MyClassA : MyBaseClass
    {
        public MyClassA()
        {
            ClassType = MyBaseClass.ClassTypeEnum.A;
        }
    }
    class MyClassB : MyBaseClass
    {
        public MyClassB()
        {
            ClassType = MyBaseClass.ClassTypeEnum.B;
        }
    }
