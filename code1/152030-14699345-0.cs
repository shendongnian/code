    public class TestDesignProperty : UITypeEditor
    {
        // ...
    
        IWindowsFormsEditorService editorService;
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                // ...
                editorService = edSvc ; // so can be referenced in the click event handler
                
                ListBox lb = new ListBox();
                lb.Click += new EventHandler(lb_Click);
                // ... 
            }
    
    
    
        void lb_Click(object sender, EventArgs e)
        {
            editorService.CloseDropDown();
        }
    
    }
