    using System.Windows.Forms;
    using Testapplication.Properties;
    
    namespace Testapplication {
        public class Class1 {
            public Class1() {
                Form MyForm = new Form();
                ToolStrip MyToolStrip = new ToolStrip();
                MyForm.Controls.Add(MyToolStrip);
    
                ToolStripButton MyButton = new ToolStripButton();
                MyToolStrip.Items.Add(MyButton);
    
                MyButton.Image = Resources.MyResourceImage;
    
                MyForm.Show();
            }
        }
    }
