    [Export(typeof(IMouseProcessorProvider))]
    [ContentType("code")]
    [TextViewRole(PredefinedTextViewRoles.Editable)]
    [Name("mouseproc")]
    internal sealed class MouseProcessorFactory : IMouseProcessorProvider
    {        
        public IMouseProcessor GetAssociatedProcessor(IWpfTextView wpfTextView)
        {            
            return new MouseProcessor();
        }
    }
