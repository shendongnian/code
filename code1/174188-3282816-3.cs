        namespace App
        {
            public class Functions
            {
                private TaskbarItemInfo _taskbarItemInfo;
    
                public TaskbarItemInfo taskbarItemInfo
               {
                   get
                  {
                       return _taskbarItemInfo;
                  }
               }
          
                public void loadFunctions()
                {
                    _taskbarItemInfo = new TaskbarItemInfo();
        
                }
            }
        }
