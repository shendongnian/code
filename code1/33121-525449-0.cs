    using System;
    using System.Windows.Forms;
    static class Program {
        [STAThread]
        static void Main() {
            // older menuitem
            MenuItem mi;
            using (Form form = new Form {
                Menu = new MainMenu {
                    MenuItems = {
                        (mi = new MenuItem("abc"))
                    }
                }
            })
            {
                mi.MenuItems.Add("dummy");
                mi.Popup += delegate {
                    mi.MenuItems.Clear();
                    mi.MenuItems.Add(DateTime.Now.ToLongTimeString());
                };
                Application.Run(form);
            }
    
            MenuStrip ms;
            ToolStripMenuItem tsmi;
            using (Form form = new Form {
                MainMenuStrip = (ms = new MenuStrip {
                    Items = {
                        (tsmi = new ToolStripMenuItem("def"))
                    }
                })
            })
            {
                form.Controls.Add(ms);
                tsmi.DropDownItems.Add("dummy");
                tsmi.DropDownOpening += delegate {
                    tsmi.DropDownItems.Clear();
                    tsmi.DropDownItems.Add(DateTime.Now.ToLongTimeString());
                };
                Application.Run(form);
            }
        }
    }
