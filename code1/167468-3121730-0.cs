    public abstract class Task
    {
        string Name;
        protected abstract bool DoEquals( Task rhs );
    
        public static bool operator ==(Task t1, Task t2)
        {
            return t1.DoEquals( t2 );
        }
    }
    
    public class TaskA : Task
    {
        protected bool DoEquals( Task rhs )
        {
            return /* custom compare */
        }
    }
    
    public class TaskB : Task
    {
        protected bool DoEquals( Task rhs )
        {
            return /* custom compare */
        }
    }
