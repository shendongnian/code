    // TaxRate.cs
    public partial abstract class TaxRate
    {
        // All the stuff apart from the nested classes
    }
    // TaxRate.Normal.cs
    public partial abstract class TaxRate
    {
        private class NormalTaxRate : TaxRate
        {
            public override string Name { get { return "Regelsteuersatz"; } }
            public override decimal Rate { get { return 20m; } }
        }
    }
    // TaxRate.Other.cs
    public partial abstract class TaxRate
    {
        private class OtherTaxRate : TaxRate
        {
            public override string Name { get { return "Something else"; } }
            public override decimal Rate { get { return 120m; } }
        }
    }
