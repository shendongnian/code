    using System;
    using System.Windows.Forms;
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            ListView lv;
            Button btn;
    
            Form form = new Form {
                Controls = {
                    (lv = new ListView { Dock = DockStyle.Fill,
                          ShowGroups = true}),
                    (btn = new Button { Dock = DockStyle.Bottom,
                          Text = "Scramblle" })
                }
            };
            Random rand = new Random();
            for (int i = 0; i < 40; i++) {
                lv.Items.Add("Item " + i);
            }
            btn.Click += delegate {
                // 1: Cycle through every item and set it's Group
                // property to null.
                foreach (ListViewItem item in lv.Items) {
                    item.Group = null;
                }
                // 2: Empty the ListView's Groups collection.
                lv.Groups.Clear();
                // 3: Add new Groups to the ListView's Group collection.
                int groupCount = rand.Next(lv.Items.Count) + 1;
                for (int i = 0; i < groupCount; i++) {
                    lv.Groups.Add("grp" + i, "Group " + i);
                }
                // 4: Cycle through every item and set the Group property
                // using a value obtained from the ListView's Group collection
                // via index.
                foreach (ListViewItem item in lv.Items) {
                    item.Group = lv.Groups[rand.Next(groupCount)];
                }
            };
            Application.Run(form);
        }
    }
