    class FooEditor : UITypeEditor
    {
        MultilineStringEditor ed = new MultilineStringEditor();
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            Foo foo = value as Foo;
            if (foo != null)
            {
                value = new Foo((string)ed.EditValue(provider, foo.Value));
            }
            return value;        
        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return ed.GetEditStyle();
        }
        public override bool  IsDropDownResizable {
    	    get { return ed.IsDropDownResizable; }
        }
    }
