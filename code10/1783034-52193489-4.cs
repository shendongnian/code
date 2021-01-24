    using System.Collections.ObjectModel;
    public static class SubClass
    {
        public static readonly ReadOnlyCollection<long> properties = 
            new ReadOnlyCollection<long>(
                new long[] { 365635, 156346, 280847 }
            );
    }
