    public class SampleClass : IDeepCloneable<SampleClass>
    {
        public SampleClass DeepClone()
        {
            // Deep clone your object
            return ...;
        }
        public object IDeepCloneable.DeepClone()
        {
            return this.DeepClone();
        }
    }
