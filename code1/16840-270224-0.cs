    using System;
    
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class SampleAttribute : Attribute
    {
        public SampleAttribute(int[] foo)
        {
        }
    }
    
    [Sample(new int[]{1, 3, 5})]
    class Test
    {
    }
