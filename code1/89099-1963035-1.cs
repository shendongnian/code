    public class NotEmptyValueFromDataTemplate : System.Web.UI.Page, IBindableTemplate
    {
        protected string p_DataFieldToLookAt;
        protected string p_ValueToPlaceInIfNotNull;
        protected Literal p_litControl;
        public RoleTemplate(string DataFieldToLookAt, string ValueToPlaceInIfNotNull)
        {
            this.p_DataFieldToLookAt = DataFieldToLookAt;
            this.p_ValueToPlaceInIfNotNull = ValueToPlaceInIfNotNull;
        }
        public virtual void OnInit(object sender, EventArgs e)
        { }
        #region IBindableTemplate Members
        public System.Collections.Specialized.IOrderedDictionary ExtractValues(Control container)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region ITemplate Members
        public void InstantiateIn(Control container)
        {
            p_litControl = new Literal();
            p_litControl.ID = p_DataFieldToLookAt; /* we don't really care */
            p_litControl.Init += new EventHandler(OnInit);
            p_litControl.DataBinding += new EventHandler(p_litControl_DataBinding);
            container.Controls.Add(p_litControl);
        }
        void p_litControl_DataBinding(object sender, EventArgs e)
        {
            var Data = ((GridViewRow)(p_litControl.NamingContainer)).DataItem;
            string ValueFromData = Convert.ToString(DataBinder.Eval(Data, p_DataFieldToLookAt));
            if(!String.IsNullOrEmpty(ValueFromData))
                p_litControl.Text = p_ValueToPlaceInIfNotNull;
        }
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
        }
        #endregion
    }
