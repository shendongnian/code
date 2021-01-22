    using System.Windows;
    using System.Windows.Controls;
    namespace SilverlightClassLibrary1
    {
        [TemplatePart(Name = ButtonName , Type = typeof(Button))]
        public class TemplatedControl1 : Control
        {
            private const string ButtonName = "Button";
            public TemplatedControl1()
            {
                DefaultStyleKey = typeof(TemplatedControl1);
            }
            private Button _button;
            public event RoutedEventHandler Click;
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
                // Detach during re-templating
                if (_button != null)
                {
                    _button.Click -= OnButtonTemplatePartClick;
                }
                _button = GetTemplateChild(ButtonName) as Button;
                // Attach to the Click event
                if (_button != null)
                {
                    _button.Click += OnButtonTemplatePartClick;
                }
            }
            private void OnButtonTemplatePartClick(object sender, RoutedEventArgs e)
            {
                RoutedEventHandler handler = Click;
                if (handler != null)
                {
                    // Consider: do you want to actually bubble up the original
                    // Button template part as the "sender", or do you want to send
                    // a reference to yourself (probably more appropriate for a
                    // control)
                    handler(this, e);
                }
            }
        }
    }
