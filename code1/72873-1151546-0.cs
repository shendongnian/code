    public interface ITask 
    {
        void Process(object o);
    }
    public class Task<T> : ITask
    { 
       void ITask.Process(object o) 
       {
          if(o is T) // Just to be sure, and maybe throw an exception
            Process(o as T);
       }
       public void Process(T o) { }
    }
