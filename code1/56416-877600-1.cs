    var path = new PropertyPath("FullName.FirstName");
    var binding = new Binding();
    binding.Source = new Person { FullName = new FullName { FirstName = "David"}}; // Just an example object similar to your question
    binding.Path = path;
    
    var evaluator = new BindingEvaluator();
    BindingOperations.SetBinding(evaluator, BindingEvaluator.TargetProperty, binding);
    var value = evaluator.Target;
    // value will now be set to "David"
    public class BindingEvaluator : DependencyObject
    {
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register(
                "Target", 
                typeof (object), 
                typeof (BindingEvaluator));
        public object Target
        {
            get { return GetValue(TargetProperty); }
        }
    }
