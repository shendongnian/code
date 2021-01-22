    namespace App
    {
        public class Functions
        {
            public TaskbarItemInfo TaskbarItemInfo { get; private set; }
            public Functions() 
            {
                loadFunctions();
            }
    
            private void loadFunctions()
            {
                TaskbarItemInfo = new TaskbarItemInfo();
            }
        }
    }
