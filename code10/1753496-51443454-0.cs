     public class ButtonBehavior : Behavior<Button>
        {
            protected override void OnAttachedTo(Button bindable)
            {
                base.OnAttachedTo(bindable);
                bindable.Clicked += Bindable_Clicked;
            }
    
            private void Bindable_Clicked(object sender, EventArgs e)
            {
                //Use you logic here
            }
    
            protected override void OnDetachingFrom(Button bindable)
            {
                base.OnDetachingFrom(bindable);
                bindable.Clicked -= Bindable_Clicked;
            }
        }
