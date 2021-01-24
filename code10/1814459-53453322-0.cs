    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    namespace WindowsFormsApp1 {
        public partial class Form1 : Form {
            private DateTime from;
            private Stopwatch watch = new Stopwatch();
            public Form1() {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e) {
                from = DateTime.Now;
                watch.Restart();
            }
            private void button2_Click(object sender, EventArgs e) {
                watch.Stop();
                MessageBox.Show(
                    "Date subtraction: " + DateTime.Now.Subtract(from).ToString() + Environment.NewLine +
                    "Stopwatch: " + watch.Elapsed.ToString());
            }
        }
    }
