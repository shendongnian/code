    interface ITimeSeriesUser<X> {
        X Use<T>(TimeSeries<T> series);
    }
    interface ITimeSeriesUser {
        void Use<T>(TimeSeries<T> series);
    }
    interface ITimeSeries {
        X Apply<X>(ITimeSeriesUser<X> user);
        void Apply(ITimeSeriesUser user);
    }
    class TimeSeries<T> : ITimeSeries {
        X Apply<X>(ITimeSeriesUser<X> user) { return user.Use(this); }
        void Apply(ITimeSeriesUser user) { return user.Use(this); }
        /* Your existing code goes here */
    }
