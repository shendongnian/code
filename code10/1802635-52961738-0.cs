    class DemoDataEqualityComparer : IEqualityComparer<DemoDataBindingByAnalysis>
    {
     public bool Equals(DemoDataBindingByAnalysis x, DemoDataBindingByAnalysis y)
     {
        return x.BCCode.Equals(y.BCCCode) && y.BCName.Equals(y.BCName); //&& more fields here.
     }
     public int GetHashCode(DemoDataBindingByAnalysis obj)
     {
        return obj.BCCode.GetHashCode();
     }
    }
