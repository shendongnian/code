    public class MyPropertyAttribute : Attribute { }
    public interface IAnimal {
        string Color { get; }
    }
    public abstract class Cat : IAnimal {
        [MyProperty]
        public string Color {
            get { return CatColor; }
        }
        protected abstract string CatColor {
            get;
        }
    }
