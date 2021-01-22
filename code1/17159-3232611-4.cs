    public class SomeForm : Form
    {
        public SomeForm()
        {
            InitializeComponent();
            if (this.IsDesignTime())
            {
                return;
            }
            // Do something that makes the visual studio crash or hang if we're in design time,
            // but any other time executes just fine
        }
    }
