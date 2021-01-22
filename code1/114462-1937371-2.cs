       public class BindingEvaluator : DependencyObject {
    
          /// <summary>
          /// Gets and Sets the binding value
          /// </summary>
          public Object BindingValue {
             get { return (Object)GetValue(BindingValueProperty); }
             set { SetValue(BindingValueProperty, value); }
          }
    
          // Using a DependencyProperty as the backing store for BindingValue.  This enables animation, styling, binding, etc...
          public static readonly DependencyProperty BindingValueProperty =
              DependencyProperty.Register("BindingValue", typeof(Object), typeof(BindingEvaluator), new UIPropertyMetadata(null));
       }
