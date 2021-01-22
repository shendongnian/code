    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    namespace Sample
    {
        public class ShapedForm : Form
        {
            Button testbutton;
            public ShapedForm()
            {
                // Create a button.
                testbutton = new Button();
                testbutton.Location = new Point(10, 10);
                testbutton.Size = new Size(50, 50);
                testbutton.Text = "Click me!";
                testbutton.Click += new EventHandler(this.testbutton_Click);
                this.Controls.Add(testbutton);
                // Remove the border around the form.
                this.FormBorderStyle = FormBorderStyle.None;
                // Set the initial shape of the form to an ellipse.
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, 200, 100);
                this.Region = new Region(path);
            }
            private void testbutton_Click(object sender, EventArgs e)
            {
                // Change the shape of the form to some other ellipse.
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, 100, 100);
                path.AddEllipse(120, 40, 50, 50);
                this.Region = new Region(path);
            }
        }
    }
