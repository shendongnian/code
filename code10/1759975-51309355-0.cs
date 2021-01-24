    public class FocusBehavior : Behavior<TextBox>
    {
       protected override void OnAttached()
        {
           base.OnAttached();
           if(AssociatedObject!=null)
           {
            //LOADED EVENT SUBSCRIBE
            AssociatedObject.Loaded += //YOUR FOCUS METHOD;
           }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            //LOADED EVENT UNSUBSCRIBE
            AssociatedObject.Loaded -= //YOUR FOCUS METHOD;
        }
       }
