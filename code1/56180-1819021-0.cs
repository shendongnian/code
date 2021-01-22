    public partial class Form1 : Form
    {
        private System.Windows.Forms.ToolTip toolTip1;
    
        public Form1()
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
    
            MyRitchTextBox myRTB = new MyRitchTextBox();
            this.Controls.Add(myRTB);
    
            myRTB.Location = new Point(10, 10);
            myRTB.MouseEnter += new EventHandler(myRTB_MouseEnter);
            myRTB.MouseLeave += new EventHandler(myRTB_MouseLeave);
        }
    
    
        void myRTB_MouseEnter(object sender, EventArgs e)
        {
            MyRitchTextBox rtb = (sender as MyRitchTextBox);
            if (rtb != null)
            {
                this.toolTip1.Show("Hello!!!", rtb);
            }
        }
    
        void myRTB_MouseLeave(object sender, EventArgs e)
        {
            MyRitchTextBox rtb = (sender as MyRitchTextBox);
            if (rtb != null)
            {
                this.toolTip1.Hide(rtb);
            }
        }
    
    
        public class MyRitchTextBox : RichTextBox
        {
        }
    
    }
