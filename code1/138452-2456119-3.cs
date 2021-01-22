     public class Register : CompositeControl
    {
        private Button submitButton;
               
        // The following properties are delegated to 
        // child controls.
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("The text to display on the button.")
        ]
        public string ButtonText
        {
            get
            {
                EnsureChildControls();
                return submitButton.Text;
            }
            set
            {
                EnsureChildControls();
                submitButton.Text = value;
            }
        }
