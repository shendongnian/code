    public static void DockControl(this Control control, UserControl userControl)
                {
                    userControl.Dock = DockStyle.Fill;
                    control.Controls.Clear();
                    control.Controls.Add(userControl);
                }
