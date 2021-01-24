    using Microsoft.AspNetCore.Blazor.Components;
    
    namespace YourApp.Pages
    {
    
        class ClassA
        {
            public int CurrentCount { get; set; }
        }
    
        class ClassB
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
            private readonly ClassA _a;
            private readonly ClassB _b;
    
            //constructor
            public void CounterBase()
            {
                ClassA _a = new ClassA();
                ClassB _b = new ClassB(_a);
            }
            ...
