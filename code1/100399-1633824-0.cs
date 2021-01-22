    class A
    {
        public string Hello { get; set; }
    }
    
    class C
    {
        private A myA;
        public C(A a) { myA = a; }
        public A GetMyA() { return myA; }
    }
    
    // somewhere else:
    A someA = new A();
    someA.Hello = "Hello World";
    C someC = new C(someA);
    someA.Hello = "Other World";
    Console.WriteLine(someC.GetMyA().Hello);
    
    // this will print "Other World" and not "Hello World" as you suggest
