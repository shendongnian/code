    public class DateTimeNowDependencyClass
    {
        ...
        public void ImplicitTimeDependencyMethod(Obj arg0)
        {
            this.TimeDependencyMethod(DateTime.Now, arg0);
        }
    
        internal void TimeDependencyMethod(DateTime now, Obj arg1)
        {
            ...
        }
        ...
    }
