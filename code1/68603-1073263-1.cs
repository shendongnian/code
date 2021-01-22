    using System;
    using System.Windows.Forms;
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            ListView list;
            TextBox txt;
            Timer tmr = new Timer();
            tmr.Interval = 200;
            Form form = new Form {
                Controls = {
                    (txt = new TextBox { Dock = DockStyle.Fill, Multiline = true}),
                    (list = new ListView { Dock = DockStyle.Right, View = View.List,
                       Items = { "abc", "def" , "ghi", "jkl", "mno" , "pqr"}})
                }
            };
            list.SelectedIndexChanged += delegate {
                tmr.Stop();
                tmr.Start();
            };
            tmr.Tick += delegate {
                tmr.Stop();
                txt.Text += "do work on " + list.SelectedItems.Count + " items"
                     + Environment.NewLine;
            };
            Application.Run(form);
        }
    }
