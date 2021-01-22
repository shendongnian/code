    public class ChangeBackgroundOnMouseEnterAndLeave
    {
        public Panel Container;
        public Label FirstLabel;
        public Label SecondLabel;
        public ChangeBackgroundOnMouseEnterAndLeave()
        {
            Container = new Panel();
            Container.Size = new Size(200, 60);
            FirstLabel = new Label();
            FirstLabel.Text = "First Label";
            FirstLabel.Top = 5;
            SecondLabel = new Label();
            SecondLabel.Text = "Second Lable";
            SecondLabel.Top = 30;
            FirstLabel.Parent = Container;
            SecondLabel.Parent = Container;
            Container.BackColor = Color.Teal;
            var transparentControl = new TranspCtrl();
            transparentControl.Size = Container.Size;
            transparentControl.MouseEnter += MouseEntered;
            transparentControl.MouseLeave += MouseLeft;
            transparentControl.Parent = Container;
            transparentControl.BringToFront();
        }
        void MouseLeft(object sender, EventArgs e)
        {
            Container.BackColor = Color.Teal;
        }
        void MouseEntered(object sender, EventArgs e)
        {
            Container.BackColor = Color.Pink;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var test = new ChangeBackgroundOnMouseEnterAndLeave();
            test.Container.Top = 20;
            test.Container.Left = 20;
            test.Container.Parent = this;
        }
    }
