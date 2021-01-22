    public static MyObservableExtensions
    {
       public static IScheduler UISafeScheduler {get;set;}
       public static IObservable<TSource> ObserveOnUISafeScheduler(this IObservable<TSource> source)
       {
           if (UISafeScheduler == null) 
           {
              throw new InvalidOperation("UISafeScheduler has not been initialised");
           }
           
           return source.ObserveOn(UISafeScheduler);
       }
    }
