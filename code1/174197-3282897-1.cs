    namespace App
    {
        public class Functions
        {
            private static TaskbarItemInfo _taskbarItemInfo;
            public static TaskbarItemInfo TaskBarItemInfoProperty
            {
                get{
                   if (_taskbarItemInfo == null) 
                   {
                      _taskbarItemInfo = new TaskbarItemInfo();
                   }
                   return _taskbarItemInfo;
                }
            }
        }
    
        public class Test
        {
            public void testFunction()
            {
               Functions.TaskBarItemInfoProperty.doSomething();
            }
        }
    }
