    public interface IPopulatable
    {
        void Populate();
    }
    public class ObjectCreator
    {
        public static T CreateBlank<T>() where T : new ()
        {
            return new T();
        }
        public static T CreatePopulated<T>() where T : IPopulatable, new()
        {
            var populatable = new T();
            populatable.Populate();
            return populatable;
        }
    }
    public class Human : IPopulatable
    {
        public string Name { get; set; }
        public void Populate()
        {
            Name = "Joe";
        }
    }
