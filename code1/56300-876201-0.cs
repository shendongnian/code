    public class MySingletonClass
    {
        private MySingletonClass currentInstance = null;
        
        public MySingletonClass CreateInstance()
        {
             if (currentInstance == null)
             {
                  currentInstance = new MySingletonClass();
             }
             else
             {
                  return currentInstance;
             }
        }
    }
