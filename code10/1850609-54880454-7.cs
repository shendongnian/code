    using Microsoft.AspNetCore.Blazor.Components;
    
    namespace YourApp.Pages
    {
    
        public class ClassA
        {
            public int CurrentCount { get; set; }
        }
    
        public class ClassB
        {
            private readonly ClassA _classA;
    
            public ClassB(ClassA classA)
            {
                _classA = classA;
            }
    
            public void IncrementCount() => _classA.CurrentCount++;
        }
    
        public class CounterBase : BlazorComponent
        {
            protected readonly ClassA _a;
            protected readonly ClassB _b;
    
            //constructor
            public CounterBase()
            {
                _a = new ClassA();
                _b = new ClassB(_a);
            }
            ...
