    public static void BarTheFirst<A, B>(this Widget<A, B> w, A a)
    {
        w.Bar(a);
    }
    public static void BarTheFirst<A, B>(this Widget<A, B> w, B b)
    {
        w.Bar(b);
    }
