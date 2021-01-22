    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      return context.PropertyDescriptor.IsReadOnly 
              ? UITypeEditorEditStyle.None 
              : UITypeEditorEditStyle.Modal;       
    }
