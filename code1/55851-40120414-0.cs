    public class WindowClosingBehavior : Behavior<Window>
        {
            protected override void OnAttached()
            {
                AssociatedObject.Closing += AssociatedObject_Closing;
            }
    
            private void AssociatedObject_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                Window window = sender as Window;
                window.Closing -= AssociatedObject_Closing;
                e.Cancel = true;
                var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.5));
                anim.Completed += (s, _) => window.Close();
                window.BeginAnimation(UIElement.OpacityProperty, anim);
            }
            protected override void OnDetaching()
            {
                AssociatedObject.Closing -= AssociatedObject_Closing;
            }
        }
