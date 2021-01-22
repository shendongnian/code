        public interface IBase
        {
            string Property { get; }
        }
        public abstract class AbstractClass : IBase
        {
            public abstract string Property { get; }
            public override string ToString()
            {
                return "I am abstract";
            }
        }
        public class ConcreteClass : AbstractClass
        {
            public override string Property
            {
                get
                {
                    return "I am Concrete";
                }
            }
        }
