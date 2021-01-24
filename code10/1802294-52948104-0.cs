    var sample = new Sample
    {
        Id = 1,
        Date = Convert.ToDateTime("2018-10-23"),
        Grocers = grocers1,
        Orders = orders1
    };
    var otherChangedSample = new Sample
    {
        Id = 1,
        Date = Convert.ToDateTime("2018-10-23"),
        Grocers = grocers1,
        Orders = orders2
    };
    class Variance
    {
        public string Prop { get; set; }
        public object valA { get; set; }
        public object valB { get; set; }
    }
    List<Variance> rt = sample.DetailedCompare(otherChangedSample);
----------
    using System.Collections.Generic;
    using System.Reflection;
    
    static class extentions
    {
        public static List<Variance> DetailedCompare<T>(this T val1, T val2)
        {
            List<Variance> variances = new List<Variance>();
            FieldInfo[] fi = val1.GetType().GetFields();
            foreach (FieldInfo f in fi)
            {
                Variance v = new Variance();
                v.Prop = f.Name;
                v.valA = f.GetValue(val1);
                v.valB = f.GetValue(val2);
                if (!v.valA.Equals(v.valB))
                    variances.Add(v);
    
            }
            return variances;
        } 
    }
