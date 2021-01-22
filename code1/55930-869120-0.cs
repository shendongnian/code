    public class ButtonContainer : Control
    {
        public Button ChildButton { get; set; }
        public static readonly DependencyProperty FirstOwnerProperty =
        DependencyProperty.Register("FirstOwner", typeof(ButtonContainer),
             typeof(Button));
        public ButtonContainer()
        {
            ChildButton = new Button();
            ChildButton.SetValue(FirstOwnerProperty, this);
        }
    }
