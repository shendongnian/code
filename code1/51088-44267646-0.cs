    namespace Test
    {
        public interface IBase<T>
        {
            void Foo();
        }
    
        public abstract class BaseClass<T> 
            where T : IBase<T>  // Forcing T to derive from IBase<T>
        { }
    
        public class Sample : BaseClass<Sample>, IBase<Sample>
        {
            void IBase<Sample>.Foo() { }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Sample sample = new Sample();
                // Error CS1061  'Sample' does not contain a definition for 'Foo' 
                // and no extension method 'Foo' accepting a first argument of type 'Sample' 
                // could be found(are you missing a using directive or an assembly reference ?)
                sample.Foo();
    
                (sample as IBase<Sample>).Foo(); // No Error
            }
        }
    }
