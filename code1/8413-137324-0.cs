    class Base {
        public Base() {
           InitializeComponent();
        }
        protected virtual void InitializeComponent() {
            ...
        }
    }
    class Derived : Base {
        private Button button1;
        public Derived() : base() {
            button1 = new Button();
        }
        protected override void InitializeComponent() {
            button1.Text = "I'm gonna throw a null reference exception"
        }
    }
