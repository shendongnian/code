        public object B { get; set; }
    }` 
    `//Child class implementation using Constructor Injection
     public class SpecificChild
    {
        public Test _test { get; set; }
        public SpecificChild(Test test)
        {
            _test = test;
        }
    }`
 
    I can also use inheritance in the above code, but it is not good as C# doesn't 
    support *multi-level inheritance* and you may need to inherit some other class in future
