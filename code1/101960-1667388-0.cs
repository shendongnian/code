    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    
    namespace MyApp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public String FilePath,
                FileContents = null;
    
            public class TextDocument
            {
                public void Save(string FilePath, String FileContents)
                {
                    File.WriteAllText(FilePath, FileContents);
                }
            }
    
            private void toolStripButton337_Click(object sender, EventArgs e)
            {
                FilePath = "this.txt";
                FileContents = "testing";
    
                TextDocument Document = new TextDocument();
                Document.Save(FilePath, FileContents);
            }
        }
    }
