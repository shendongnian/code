    public struct Vector2D : UITypeEditor
    {
		//UITypeEditor Implementation
	
		//Gets the editor style, (dropdown, value or new window)
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
		//Gets called when the value has to be edited.
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
			//Calls a dialog to edit the object in
            EditTypeConfig editor = new EditTypeConfig((TypeConfig)value);
            editor.Text = context.PropertyDescriptor.Name;
            if (editor.ShowDialog() == DialogResult.OK)
                return editor.SelectedObject;
            else
                return (TypeConfig)value;
        }
		
		//Properties
		
        [DisplayName("X"), Description("X is something"), Category("Value"), ReadOnly(false)]
        public double X { get; set; }
        [DisplayName("Y"), Description("Y is something"), Category("Value"), ReadOnly(false)]
        public double Y { get; set; }
    }
