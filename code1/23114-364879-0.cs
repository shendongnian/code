    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            CheckBox chk = new CheckBox();
            chk.IsChecked = false;
            LayoutRoot.Children.Remove(chkTest);
            LayoutRoot.Children.Add(chk);
        }
    }
