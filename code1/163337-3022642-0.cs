    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    using System.Net;
    namespace WithColumns
    {
        public class FormWithColumns : Form
        {
            public FormWithColumns()
            {
                Label label1 = new Label();
                    Label label2 = new Label();
                    
                SuspendLayout();
                WebRequest req = WebRequest.Create("http://www.bc.edu/bc_org/avp/cas/fnart/arch/greek/doric1.jpg");
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();
                Image img = Image.FromStream(stream);
                stream.Close();
                ClientSize = new Size(img.Width * 3, img.Height);
                label1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
                label1.Location = new System.Drawing.Point(0, 0);
                label1.Size = img.Size;
                label1.Image = img;
                label2.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                label2.Location = new System.Drawing.Point(img.Width * 2, 0);
                label2.Size = img.Size;
                label2.Image = img;
                Controls.Add(label1);
                Controls.Add(label2);
                Text = "Form With Columns";
                BackColor = Color.White;
                ResumeLayout(false);
            }
        }
    }
