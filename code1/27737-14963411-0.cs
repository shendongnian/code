    class ChildClass : ParentClass {
        override public int methodTwo() {
            return 2;
        }
        public int ParentClass_methodTwo() {
            return base.methodTwo();
        }
    }
    // Now instead of
    Console.WriteLine("ParentClass methodTwo: " + ((ParentClass)a).methodTwo());
    // use
    Console.WriteLine("ParentClass methodTwo: " + a.ParentClass_methodTwo());
