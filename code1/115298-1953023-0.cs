        public class ClassA
        {
        }
        public class ClassB : ClassA
        {
        }
        public class GeneralClass
        {
            public ClassA myClass { get; set; }
        }
        public class SpecificClass : GeneralClass
        {
            new public ClassB myClass { get; set; }
        }
        public myFunction()
        {
            var sc = new SpecificClass();
            sc.myClass = new ClassB();
            Console.WriteLine("sc.GetType() = " + sc.myClass.GetType());
            var gc = (GeneralClass)sc;
            gc.myClass = new ClassA();
            Console.WriteLine("gc.GetType() = " + gc.myClass.GetType());
            Console.WriteLine("sc.GetType() = " + sc.myClass.GetType());
        }
