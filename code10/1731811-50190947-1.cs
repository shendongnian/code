    public class SomeClass 
    { 
        public int First { get; set; }
        public int Second { get; set; }
    }
    var one = new SomeClass { First = 1, Second = 5 };
    var two = new SomeClass { First = 5, Second = 1 };
    Func<SomeClass, int> referrer = null;
    
    switch (field) 
    {
        case "first":
            referrer = x => x.First;
            break;
        case "second":
            referrer = x => x.Second;
            break;
    }
    if (referrer(one) < referrer(two))
    {
    }
