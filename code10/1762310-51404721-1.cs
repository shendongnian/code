    public interface IClass
    {
         int PlayerScore { get; }
    }
    public class ClassA : IClass
    {
        public int PlayerScore { get; } = 250;
    }
    public class ClassB
    {
        public ClassB(IClass aClass)
        {
            _aClass = aClass;
            // Now you can use _aClass.PlayerScore in the other methods
        }
        private readonly IClass _aClass;
    }
