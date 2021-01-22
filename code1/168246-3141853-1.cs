    public class StrBase : Base
    {
      private string propValue;
      
      public override object prop {
        get
        {
          return this.propValue;
        }
        set
        {
          if (value is string)
          {
            this.propValue = (string)value;
          }
        }
      }
    }
