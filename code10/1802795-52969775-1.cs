    public class A { public int Attr; }
    private static void SO_52969048()
    {
        bool? B ;
        var inputs = new List<A> {
            new A{ Attr = 0},
            new A{ Attr = 2},
            new A{ Attr = -1},
            null
        };
        foreach (var a in inputs)
        {
            B = a == null ? (bool?)null : a.Attr > 0;
            Console.WriteLine($" A  {(a == null ? "is null" : "is not null")}, A.Attr = {(a == null ? "is null" : a.Attr.ToString())} => B= {(B == null ? "is null" : B.ToString())}");
        }
    }
