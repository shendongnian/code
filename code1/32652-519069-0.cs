    public abstract class Task {    
        protected virtual void UpdateNonSharedData() { }
    
        public virtual void Method()    
        {   
            UpdateNonSharedData();    
        }
    }
    
    public abstract class TaskWithSharedData : Task {    
        private static object LockObject = new object();    
    
        protected virtual void UpdateSharedData() { }
    
        public overrides void Method()    
        {       
            lock(LockObject)
            {          
                UpdateSharedData();       
            }   
            base.Method();
        }
    }
