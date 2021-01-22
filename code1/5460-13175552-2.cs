    public class ClassA:IDisposable
    {
       #region IDisposable Members        
        public void Dispose()
        {            
            GC.SuppressFinalize(this);
        }
        #endregion
    }
----------
 
    public void fn_Data()
        {
         using (ClassA ObjectName = new ClassA())
                {
                    //use objectName 
                }
        }
