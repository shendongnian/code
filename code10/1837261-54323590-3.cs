    using System.Windows.Controls;
    using System.Windows.Interactivity;
    
    [...]
    
    public class HideComboxBehavior : Behavior<ComboBox>
    {
        protected override void OnAttached()
        {
            if (AssociatedObject.Items == null || AssociatedObject.Items == 0)
                AssociatedObject.Visibility = System.Windows.Visibility.Hidden;                               
        }
    }
