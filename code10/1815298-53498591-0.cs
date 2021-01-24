    public class Class1
    {
        public interface ITranslatable { }
    
        public interface ITranslatableOut
        {
            ITranslatable Origin { set; }
        }
    
        public class OriginClass : ITranslatable
        {
            public string Custom { get; set; }
        }
    
        public abstract class TargetBase : ITranslatableOut
        {
            public ITranslatable Origin { set { Initialize(value); } }
    
            protected abstract void Initialize(ITranslatable input);
        }
    
        public class TargetClass : TargetBase
        {
            protected override void Initialize(ITranslatable input)
            {
                // Initialize some properties
            }
        }
    
        public class Test
        {
            public Y Execute<X, Y>(X origin, Y target)
                where X : ITranslatable
                where Y : ITranslatableOut, new()
            {
                target = new Y { Origin = origin }; // It works !
                // Some stuff
                return target;
            }
        }
    
        public TargetClass Function(OriginClass origin, TargetClass target)
        {
            var test = new Test();
            return test.Execute(origin, target);
        }
    }
