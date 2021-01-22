    public class UIControl
    {
        //Want to throw an ApplicationException if developer uses this constructor and passes
        //chkSelect = null
        public UIControl(string sFieldName, HtmlInputCheckBox chkSelect)
        {
          if (chkSelect == null)
          {
            throw new ApplicationException("Dev is using the incorrect constructor");
          }
          this.FName= sFieldName;
          this.SelectCheckBox = chkSelect;
        }
    
        public UIControl(string sFieldName, HtmlInputCheckBox chkSelect, bool overrideSelect)
        {
          this.FName= sFieldName;
          this.SelectCheckBox = chkSelect;  // note: chkSelect MAY be null here.
    
          OverrideSelect = overrideSelect;
        }
      }
