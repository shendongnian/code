    public class SecurePage : UserControl
    {
        //Your code here...
        private FrameworkElement TemplateRoot { get; set; }
        public override void OnApplyTemplate()
        {
            if (Template != null)
                TemplateRoot = GetVisualChild(0) as FrameworkElement;
            else
                TemplateRoot = null;
        }
        public bool GoToVisualState(string name, bool useTransitions)
        {
            if (TemplateRoot is null)
                return false;
            return VisualStateManager.GoToElementState(TemplateRoot, name, useTransitions);
        }
    }
