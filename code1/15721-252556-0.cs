        public class RangeValidatorEx : BaseValidator
    {
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            if (base.RenderUplevel)
            {
                string clientId = this.ClientID;
                
                // The attribute evaluation funciton holds the name of client-side js function.
                Page.ClientScript.RegisterExpandoAttribute(clientId, "evaluationfunction", "RangeValidatorEx");
                Page.ClientScript.RegisterExpandoAttribute(clientId, "Range1High", this.Range1High.ToString());
                Page.ClientScript.RegisterExpandoAttribute(clientId, "Range2High", this.Range2High.ToString());
                Page.ClientScript.RegisterExpandoAttribute(clientId, "Range1Low", this.Range1Low.ToString());
                Page.ClientScript.RegisterExpandoAttribute(clientId, "Range2Low", this.Range2Low.ToString());
            }
        }
        // Will be invoked to validate the parameters 
        protected override bool ControlPropertiesValid()
        {
            if ((Range1High <= 0) || (this.Range1Low <= 0) || (this.Range2High <= 0) || (this.Range2Low <= 0))
                throw new HttpException("The range values cannot be less than zero");
            return base.ControlPropertiesValid();
        }
        // used to validation on server-side
        protected override bool EvaluateIsValid()
        {
            int code;
            if (!Int32.TryParse(base.GetControlValidationValue(ControlToValidate), out code))
                return false;
            if ((code < this.Range1High && code > this.Range1Low) || (code < this.Range2High && code > this.Range2Low))
                return true;
            else
                return false;
        }
        // inject the client-side script to page
        protected override void OnPreRender(EventArgs e)
        {
               base.OnPreRender(e);
               if (base.RenderUplevel)
               {
                   this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RangeValidatorEx", RangeValidatorExJs(),true);
               }
        }
        string RangeValidatorExJs()
        {
            string js;
            // the validator will be rendered as a SPAN tag on the client-side and it will passed to the validation function.
            js = "function RangeValidatorEx(val){ "
            + " var code=document.getElementById(val.controltovalidate).value; "
            + " if ((code < rangeValidatorCtrl.Range1High && code > rangeValidatorCtrl.Range1Low ) || (code < rangeValidatorCtrl.Range2High && code > rangeValidatorCtrl.Range2Low)) return true; else return false;}";
            return js;
        }
        public int Range1Low
        {
            get {
                object obj2 = this.ViewState["Range1Low"];
                if (obj2 != null)
                    return System.Convert.ToInt32(obj2);
                return 0;
            }
            set { this.ViewState["Range1Low"] = value; }
        }
        public int Range1High
        {
            get
            {
                object obj2 = this.ViewState["Range1High"];
                if (obj2 != null)
                    return System.Convert.ToInt32(obj2);
                return 0;
            }
            set { this.ViewState["Range1High"] = value; }
        }
        public int Range2Low
        {
            get
            {
                object obj2 = this.ViewState["Range2Low"];
                if (obj2 != null)
                    return System.Convert.ToInt32(obj2);
                return 0;
            }
            set { this.ViewState["Range2Low"] = value; }
        }
        public int Range2High
        {
            get
            {
                object obj2 = this.ViewState["Range2High"];
                if (obj2 != null)
                    return System.Convert.ToInt32(obj2);
                return 0;
            }
            set { this.ViewState["Range2High"] = value; }
        }
    }
