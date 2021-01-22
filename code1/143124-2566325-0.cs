    public partial class Form1 : Form
    {
            private void button1_Click(object sender, EventArgs e)
            {
                Util.PlaceControlToContainer(this.button1, this.panel2);
            }
    }
    public static class Util
    {
       public static void PlaceControlToContainer(Control control, Control container)
       {
           lock (control)
           {
              if (control.Parent != null)
              {
                  control.Parent.Controls.Remove(control);
              }
              container.Controls.Add(control);
           }
       }
    }
