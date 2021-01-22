    using System.Windows.Forms;
    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var frm = new Form();
            frm.Name = "Hello";
            var lb = new Label();
            lb.Text = "Hello World!!!";
            frm.Controls.Add(lb);
            frm.ShowDialog();
        }
    }
