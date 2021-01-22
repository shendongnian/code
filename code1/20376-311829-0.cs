    public interface IRandomGenerator
    {
        double Generate(double max);
    }
    
    public class SomethingThatUsesRandom
    {
        private readonly IRandomGenerator _generator;
    
        private class DefaultRandom : IRandomGenerator
        {
            public double Generate(double max)
            {
                return (new Random()).Next(max);
            }
        }
    
        public SomethingThatUsesRandom(IRandomGenerator generator)
        {
            _generator = generator;
        }
    
        public SomethingThatUsesRandom() : this(new DefaultRandom())
        {}
    
        public double MethodThatUsesRandom()
        {
            return _generator.Generate(40.0);
        }
    }
