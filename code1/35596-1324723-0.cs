                foreach (Control control in crystalReportViewer1.Controls)
                {
                    if (control is CrystalDecisions.Windows.Forms.PageView)
                    {
                        TabControl tab = (TabControl)(CrystalDecisions.Windows.Forms.PageView)control).Controls[0];
                        tab.ItemSize = new Size(0, 1);
                        tab.SizeMode = TabSizeMode.Fixed;
                        tab.Appearance = TabAppearance.Buttons;
                    }
                }
