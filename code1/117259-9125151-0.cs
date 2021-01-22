    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    public class BindableToolStripButton : ToolStripButton, IBindableComponent
    {
        public BindableToolStripButton()
            : base() { }
        public BindableToolStripButton(String text)
            : base(text) { }
        public BindableToolStripButton(System.Drawing.Image image)
            : base(image) { }
        public BindableToolStripButton(String text, System.Drawing.Image image)
            : base(text, image) { }
        public BindableToolStripButton(String text, System.Drawing.Image image, EventHandler onClick)
            : base(text, image, onClick) { }
        public BindableToolStripButton(String text, System.Drawing.Image image, EventHandler onClick, String name)
            : base(text, image, onClick, name) { }
        #region IBindableComponent Members
        private BindingContext bindingContext;
        private ControlBindingsCollection dataBindings;
        [Browsable(false)]
        public BindingContext BindingContext
        {
            get
            {
                if (bindingContext == null)
                {
                    bindingContext = new BindingContext();
                }
                return bindingContext;
            }
            set
            {
                bindingContext = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (dataBindings == null)
                {
                    dataBindings = new ControlBindingsCollection(this);
                }
                return dataBindings;
            }
        }
        #endregion
    }
