      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
          var f2 = new Form2();
          f2.TopLevel = false;
          f2.Location = new Point(5, 5);
          f2.FormBorderStyle = FormBorderStyle.None;
          f2.Visible = true;
          this.Controls.Add(f2);
        }
      }
