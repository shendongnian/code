    static struct DateTime 
    {
        static DateTime Now
        {
            get 
            {
                Func<DateTime> d = __Detours.GetDelegate(
                    null, // this point null in static methods
                    methodof(here) // current method token
                    );
                if(d != null)
                    return d();
                ... // original body
            }
        }
    }
