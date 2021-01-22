    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal), Designer(typeof(VacationHomeDesigner)), DefaultProperty("Title"), ToolboxData("<{0}:TemplateContainer runat=\"server\"> </{0}:TemplateContainer>"),]
    public class TemplateContainer : CompositeControl
    {
        private ITemplate templateValue;
        private TemplateOwner ownerValue;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TemplateOwner Owner
        {
            get
            {
                return ownerValue;
            }
        }
        [Browsable(false), PersistenceMode(PersistenceMode.InnerProperty), DefaultValue(typeof(ITemplate), ""), Description("Control template"), TemplateContainer(typeof(TemplateContainer))]
        public virtual ITemplate Template
        {
            get
            {
                return templateValue;
            }
            set
            {
                templateValue = value;
            }
        }
        
        protected override void CreateChildControls()
        {
            Controls.Clear();
            ownerValue = new TemplateOwner();
            ITemplate temp = templateValue;
            if (temp == null)
            {
                temp = new DefaultTemplate();
            }
            temp.InstantiateIn(ownerValue);
            this.Controls.Add(ownerValue);
        }
        public override void DataBind()
        {
            CreateChildControls();
            ChildControlsCreated = true;
            base.DataBind();
        }
    }
    [ToolboxItem(false)]
    public class TemplateOwner : WebControl
    {
    }
    #region DefaultTemplate
    sealed class DefaultTemplate : ITemplate
    {
        void ITemplate.InstantiateIn(Control owner)
        {
            // Create Controls Here
            //Label title = new Label();
            //title.DataBinding += new EventHandler(title_DataBinding);
            //owner.Controls.Add(title);
        }
        //void title_DataBinding(object sender, EventArgs e)
        //{
        //    Label source = (Label)sender;
        //    TemplateContainer container = (TemplateContainer)(source.NamingContainer);
        //    source.Text = container.Title;
        //}
    }
    #endregion
    public class VacationHomeDesigner : ControlDesigner
    {
        public override void Initialize(IComponent Component)
        {
            base.Initialize(Component);
            SetViewFlags(ViewFlags.TemplateEditing, true);
        }
        public override string GetDesignTimeHtml()
        {
            return "<span>[Template Container Control]</span>";
        }
        public override TemplateGroupCollection TemplateGroups
        {
            get
            {
                TemplateGroupCollection collection = new TemplateGroupCollection();
                TemplateGroup group;
                TemplateDefinition template;
                TemplateContainer control;
                control = (TemplateContainer)Component;
                group = new TemplateGroup("Item");
                template = new TemplateDefinition(this, "Template", control, "Template", true);
                group.AddTemplateDefinition(template);
                collection.Add(group);
                return collection;
            }
        }
        
    }
}
