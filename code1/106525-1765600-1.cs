    using LogEnum= Project.Logging.Logging.LogPriority;
    
    namespace Project.SomeName
    {
        internal class MyClass
        {
            public MyClass()
            {
                LogEnum enum1 = LogEnum.None;
            }
        }
    }
    namespace Project.Logging
    {
        public static class Logging
        {
            public enum LogPriority
            {
                None,
                Default
            }
        }
    }
