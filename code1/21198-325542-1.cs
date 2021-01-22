     public abstract class TaxRate
     {
         public static readonly TaxRate Normal = new NormalTaxRate();
         public static readonly TaxRate Whatever = new OtherTaxRate();
         // Only allow nested classes to derive from this - and we trust those!
         private TaxRate() {}
         public abstract string Name { get; }
         public abstract decimal Rate { get; }
         private class NormalTaxRate : TaxRate
         {
             public override string Name { get { return "Regelsteuersatz"; } }
             public override decimal Rate { get { return 20m; } }
         }
         private class OtherTaxRate : TaxRate
         {
             public override string Name { get { return "Something else"; } }
             public override decimal Rate { get { return 120m; } }
         }
     }
