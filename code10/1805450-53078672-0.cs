    public class MyUserControl : UserControl
    {
        // [...]
        public string Title { get; private set; }
        public event EventHandler TitleChanged;
        // [...]
        private void MyTextBox_TextChanged(object sender, EventArgs e)
        {
            Title = MyTextBox.Text;
            TitleChanged?.Invoke(this, EventArgs.Empty);
        }
    }
