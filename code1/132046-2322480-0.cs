    public static class WidgetExtensions
    {
        public static bool Bar1<T1,T2>(this Widget<T1, T2> w, T1 t1) { return w.Bar(t1); }
        public static bool Bar2<T1,T2>(this Widget<T1, T2> w, T2 t2) { return w.Bar(t2); }
    }
