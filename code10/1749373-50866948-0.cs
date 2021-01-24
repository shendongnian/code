    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    namespace ClassLibrary1
    {
        public class ClassFactory
        {
            private IDictionary<int, Func<int, BaseClass>> ClassMap { get; } = new Dictionary<int, Func<int, BaseClass>>()
            {
                {1, x => new ClassA(x) },
                {2, x => new ClassB(x) }
            };
    
            private IDictionary<Type, Func<BaseClass, Task>> ClassInitializeMap { get; } = new Dictionary<Type, Func<BaseClass,  Task>()
            {
                {typeof(ClassA) , (cls) => Task.Delay(1000) }, //Do Something with "Foo" 
                {typeof(ClassB) , (cls) => Task.Delay(1000) } 
            };
    
            public async Task ProcessVariable(int variable)
            {
                var theClass = ClassMap[variable](variable);
                await OnAnyClass(theClass).ConfigureAwait(false);
                await ClassInitializeMap[theClass.GetType()](theClass).ConfigureAwait(false);
            }
    
            public Task OnAnyClass<T>(T anyClass) => Task.Delay(1000);
        }
    
        public abstract class BaseClass
        {
            public int Foo;
        }
        public class ClassA : BaseClass
        {
            public ClassA(int variable) => Foo = variable;
        }
        public class ClassB : BaseClass
        {
            public ClassB(int variable) => Bar = variable;
            public int Bar;
        }
    }
