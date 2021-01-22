    public class MyForm : Form
    {
        IMyInterface cName;
        public MyForm()
        {
            InitializeComponent();
            cName = new MyUserControl();
            Controls.Add((UserControl)cName);
        }
    }
