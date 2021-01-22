    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1 {
        public partial class Form1 : Form {
            void SortListBox() {
                List<string> items = new List<string>();
                foreach (string value in listBox1.Items) {
                    items.Add(value);
                }
                items.Sort((first, second) => string.Compare(first, second));
                listBox1.Items.Clear();
                listBox1.Items.AddRange(items.ToArray());
            }
        }
    }
