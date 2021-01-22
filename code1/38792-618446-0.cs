        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI.WebControls;
    
    /// <summary>
    /// Summary description for BindingRadioButtonList
    /// </summary>
    public class BindingRadioButtonList : RadioButtonList
    {
        public string Value
        {
            get
            {
                return this.SelectedValue;
            }
            set
            {
                if (this.Items.FindByValue(value) != null)
                {
                    this.ClearSelection();
                    this.Items.FindByValue(value).Selected = true;
                }
            }
        }
    
    	public BindingRadioButtonList()
    	{
    		//
    		// TODO: Add constructor logic here
    		//
    	}
    }
