    internal class DefectPropertyInternal
    {
      private IDefectproperty dp
      public DefectPropertyInternal(IDefectproperty dp)
      {
         this.dp = dp;
      }
    
      public DateTime SubmitDateAsDate
      {
        get { return DateTime.Parse(dp.SubmitDate); }
        set { dp.SubmitDate = value.ToString(); }
      }
    
    }
    
    public class Defect : IDefectProperty
    {
      private DefectPropertyInternal dpi;
    
      public Defect()
      {
         this.dpi = new DefectpropertyInternals(this);
      }
    
     public DateTime SubmitDateAsDate
     {
        get { return dpi.SubmitDateAsDate; }
        set { dpi.SubmitDateAsDate = value; }
     }
    
    }
