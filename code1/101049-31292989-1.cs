    public class AttachableForStyleBehavior<TComponent, TBehavior> : Behavior<TComponent>
            where TComponent : System.Windows.DependencyObject
            where TBehavior : AttachableForStyleBehavior<TComponent, TBehavior> , new ()
        {
            public static DependencyProperty IsEnabledForStyleProperty =
                DependencyProperty.RegisterAttached("IsEnabledForStyle", typeof(bool),
                typeof(AttachableForStyleBehavior<TComponent, TBehavior>), new FrameworkPropertyMetadata(false, OnIsEnabledForStyleChanged)); 
    
            public static void SetIsEnabledForStyle(UIElement element, bool value)
            {
                element.SetValue(IsEnabledForStyleProperty, value);
            }
            public static bool GetIsEnabledForStyle(UIElement element)
            {
                return (bool)element.GetValue(IsEnabledForStyleProperty);
            }
    
            private static void OnIsEnabledForStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                UIElement uie = d as UIElement;
                if (uie != null)
                {
                    var behColl = Interaction.GetBehaviors(uie);
                    var existingBehavior = behColl.FirstOrDefault(b => b.GetType() ==
                          typeof(TBehavior)) as TBehavior;
    
                    if ((bool)e.NewValue == false && existingBehavior != null)
                    {
                        behColl.Remove(existingBehavior);
                    }
    
                    else if ((bool)e.NewValue == true && existingBehavior == null)
                    {
                        behColl.Add(new TBehavior());
                    }    
                }
            }
        }
