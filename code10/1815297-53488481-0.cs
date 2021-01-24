     public class Class1
    {
        public interface ITranslatable { }
        public interface ITranslatable<T>
        {
            T Origin { get; set; }
        }
        public class OriginClass : ITranslatable
        {
        }
        public class TargetClass : ITranslatable<OriginClass>
        {
            private OriginClass _origin;
            public OriginClass Origin
            {
                get => _origin;
                set
                {
                    //Do some stuff
                    _origin = value;
                }
            }
            public TargetClass()
            {
                
            }
           
        }
        public class Test
        {
            public Y Execute<X, Y>(X origin, Y target)
                where X : ITranslatable
                where Y : ITranslatable<X>, new()
            {
                var result = new Y {Origin = origin};
                
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
