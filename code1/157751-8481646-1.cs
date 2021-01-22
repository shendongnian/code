    public class MyTextBox : TextBox
    {
        private String readOnlyText;
        public String ReadOnlyText
        {
            get
            {
                return readOnlyText;
            }
            set
            {
                readOnlyText = value;
                this.Text = readOnlyText;
            }
        }
        public MyTextBox()
        {
            BorderThickness = new Thickness(0);
            Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            BorderBrush = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            this.TextWrapping = System.Windows.TextWrapping.Wrap;
            this.GotFocus += new RoutedEventHandler(MyTextBox_GotFocus);
            this.MouseEnter += new MouseEventHandler(MyTextBox_MouseEnter);
            this.MouseMove += new MouseEventHandler(MyTextBox_MouseMove);
            this.TextChanged += new TextChangedEventHandler(MyTextBox_TextChanged);
        }
        void MyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ReadOnlyText))
            {
                var lS = this.SelectionStart; var lL = this.SelectionLength;
                this.Text = this.ReadOnlyText;
                this.SelectionStart = lS; this.SelectionLength = lL;
            }
        }
        void MyTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "Normal", false);
        }
        void MyTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "Normal", false);
        }
        void MyTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "Normal", false);
        }
    }
