    var binding = new Binding("FullName.FirstName");
    binding.Source = new Person { FullName = new FullName { FirstName = "David"}};
    
    var evaluator = new BindingEvaluator();
    BindingOperations.SetBinding(evaluator, BindingEvaluator.TargetProperty, binding);
    var value = evaluator.Target;
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
