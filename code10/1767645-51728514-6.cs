    using System.Windows.Forms;
    namespace TestProject
    {
        // Note. Only public classes are exported to COM!
        public class Test
        {
            // Note. Only public methods are exported to COM!
            public void testIt() {
                MessageBox.Show("Yellow world");
            }
        }
    }
