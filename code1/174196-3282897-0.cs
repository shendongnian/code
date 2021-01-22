    namespace App
    {
        public class Functions
        {
            private static TaskbarItemInfo taskbarItemInfo;
            public static TaskbarItemInfo TaskBarItemInfoProperty
            {
                get{
                   if (taskbarItemInfo == null) 
                   {
                      taskbarItemInfo = new TaskbarItemInfo();
                   }
                   return taskbarItemInfo;
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
