        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Windows.Forms;
        
        namespace EnterBrokenExample
        {
            static class Program
            {
                /// <summary>
                /// The main entry point for the application.
                /// </summary>
                [STAThread]
                static void Main()
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
        
                    Form Form1 = new Form();
                    Form c1 = new Form();
                    Form c2 = new Form();
        
                    Form1.IsMdiContainer = true;
        
                    c1.MdiParent = Form1;
                    c2.MdiParent = Form1;
        
                    c1.Show();
                    c2.Show();
        
                    TextBox tb1 = new TextBox();
                    c1.Controls.Add(tb1);
                    tb1.Enter += ontbenter;
                    tb1.Text = "Some Text";
                    tb1.GotFocus += ongotfocus;
        
                    TextBox tb2 = new TextBox();
                    c2.Controls.Add(tb2);
                    tb2.Enter += ontbenter;
                    tb2.Text = "some other text";
                    tb2.GotFocus += ongotfocus;
        
                    Application.Run(Form1);
                }
                static void ontbenter(object sender, EventArgs args)
                {
                    if (!(sender is TextBox))
                        return;
                    TextBox s = (TextBox)sender;
                    s.SelectAll();
                }
        
                static void ongotfocus(object sender, EventArgs args)
                {
                    if (!(sender is TextBox))
                        return;
                    TextBox s = (TextBox)sender;
                    s.SelectAll();
                }
            }
        }
