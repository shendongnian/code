        static readonly int iterations = 50000000;
        void IsTest()
        {
            Process.GetCurrentProcess().ProcessorAffinity = (IntPtr)1;
            MyBaseClass[] bases = new MyBaseClass[iterations];
            bool[] results1 = new bool[iterations];
            Stopwatch createTime = new Stopwatch();
            createTime.Start();
            DateTime createStart = DateTime.UtcNow;
            for (int i = 0; i < iterations; i++)
            {
                if (i % 2 == 0) bases[i] = new MyClassA();
                else bases[i] = new MyClassB();
            }
            DateTime createStop = DateTime.UtcNow;
            createTime.Stop();
            
            Stopwatch isTimer = new Stopwatch();
            isTimer.Start();
            DateTime isStart = DateTime.UtcNow;
            for (int i = 0; i < iterations; i++)
            {
                results1[i] =  bases[i] is MyClassB;
            }
            DateTime isStop = DateTime.UtcNow; 
            isTimer.Stop();
            CheckResults(ref  results1);
            Stopwatch asTimer = new Stopwatch();
            asTimer.Start();
            DateTime asStart = DateTime.UtcNow;
            for (int i = 0; i < iterations; i++)
            {
                results1[i] = bases[i] as MyClassB != null;
            }
            DateTime asStop = DateTime.UtcNow; 
            asTimer.Stop();
            CheckResults(ref  results1);
            Stopwatch baseMemberTime = new Stopwatch();
            baseMemberTime.Start();
            DateTime baseStart = DateTime.UtcNow;
            for (int i = 0; i < iterations; i++)
            {
                results1[i] = bases[i].ClassType == MyBaseClass.ClassTypeEnum.B;
            }
            DateTime baseStop = DateTime.UtcNow;
            baseMemberTime.Stop();
            CheckResults(ref  results1);
            Stopwatch baseFieldTime = new Stopwatch();
            baseFieldTime.Start();
            DateTime baseFieldStart = DateTime.UtcNow;
            for (int i = 0; i < iterations; i++)
            {
                results1[i] = bases[i].ClassTypeField == MyBaseClass.ClassTypeEnum.B;
            }
            DateTime baseFieldStop = DateTime.UtcNow;
            baseFieldTime.Stop();
            CheckResults(ref  results1);
                            
            Stopwatch baseROFieldTime = new Stopwatch();
            baseROFieldTime.Start();
            DateTime baseROFieldStart = DateTime.UtcNow;
            for (int i = 0; i < iterations; i++)
            {
                results1[i] = bases[i].ClassTypeField == MyBaseClass.ClassTypeEnum.B;
            }
            DateTime baseROFieldStop = DateTime.UtcNow;
            baseROFieldTime.Stop();
            CheckResults(ref  results1);
            
            Stopwatch virtMethTime = new Stopwatch();
            virtMethTime.Start();
            DateTime virtStart = DateTime.UtcNow;
            for (int i = 0; i < iterations; i++)
            {
                results1[i] = bases[i].GetClassType() == MyBaseClass.ClassTypeEnum.B;
            }
            DateTime virtStop = DateTime.UtcNow;
            virtMethTime.Stop();
            CheckResults(ref  results1);
            Stopwatch virtMethBoolTime = new Stopwatch();
            virtMethBoolTime.Start();
            DateTime virtBoolStart = DateTime.UtcNow;
            for (int i = 0; i < iterations; i++)
            {
                results1[i] = bases[i].IsB();
            }
            DateTime virtBoolStop = DateTime.UtcNow;
            virtMethBoolTime.Stop();
            CheckResults(ref  results1);
            asdf.Text +=
            "Stopwatch: " + Environment.NewLine 
              +   "As:  " + asTimer.ElapsedMilliseconds + "ms" + Environment.NewLine
               +"Is:  " + isTimer.ElapsedMilliseconds + "ms" + Environment.NewLine
               + "Base property:  " + baseMemberTime.ElapsedMilliseconds + "ms" + Environment.NewLine + "Base field:  " + baseFieldTime.ElapsedMilliseconds + "ms" + Environment.NewLine + "Base RO field:  " + baseROFieldTime.ElapsedMilliseconds + "ms" + Environment.NewLine + "Virtual GetEnumType() test:  " + virtMethTime.ElapsedMilliseconds + "ms" + Environment.NewLine + "Virtual IsB() test:  " + virtMethBoolTime.ElapsedMilliseconds + "ms" + Environment.NewLine + "Create Time :  " + createTime.ElapsedMilliseconds + "ms" + Environment.NewLine + Environment.NewLine+"UtcNow: " + Environment.NewLine + "As:  " + (asStop - asStart).Milliseconds + "ms" + Environment.NewLine + "Is:  " + (isStop - isStart).Milliseconds + "ms" + Environment.NewLine + "Base property:  " + (baseStop - baseStart).Milliseconds + "ms" + Environment.NewLine + "Base field:  " + (baseFieldStop - baseFieldStart).Milliseconds + "ms" + Environment.NewLine + "Base RO field:  " + (baseROFieldStop - baseROFieldStart).Milliseconds + "ms" + Environment.NewLine + "Virtual GetEnumType():  " + (virtStop - virtStart).Milliseconds + "ms" + Environment.NewLine + "Virtual bool IsB():  " + (virtBoolStop - virtBoolStart).Milliseconds + "ms" + Environment.NewLine + "Create Time :  " + (createStop-createStart).Milliseconds + "ms" + Environment.NewLine;
        }
    }
    abstract class MyBaseClass
    {
        public enum ClassTypeEnum { A, B }
        public ClassTypeEnum ClassType { get; protected set; }
        public ClassTypeEnum ClassTypeField;
        public readonly ClassTypeEnum ClassTypeReadonlyField;
        public abstract ClassTypeEnum GetClassType();
        public abstract bool IsB();
        protected MyBaseClass(ClassTypeEnum kind)
        {
            ClassTypeReadonlyField = kind;
        }
    }
    class MyClassA : MyBaseClass
    {
        public override bool IsB() { return false; }
        public override ClassTypeEnum GetClassType() { return ClassTypeEnum.A; }
        public MyClassA() : base(MyBaseClass.ClassTypeEnum.A)
        {
            ClassType = MyBaseClass.ClassTypeEnum.A;
            ClassTypeField = MyBaseClass.ClassTypeEnum.A;            
        }
    }
    class MyClassB : MyBaseClass
    {
        public override bool IsB() { return true; }
        public override ClassTypeEnum GetClassType() { return ClassTypeEnum.B; }
        public MyClassB() : base(MyBaseClass.ClassTypeEnum.B)
        {
            ClassType = MyBaseClass.ClassTypeEnum.B;
            ClassTypeField = MyBaseClass.ClassTypeEnum.B;
        }
    }
