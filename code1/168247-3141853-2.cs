    public class StrBase : Base
    {
      public string strProp {
        get
        {
          return (string)this.prop;
        }
        set
        {
          this.prop = value;
        }
      }
    }
