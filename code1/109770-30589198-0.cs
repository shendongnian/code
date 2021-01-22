     void MakeMDIChild_Simplest(Type thisForm)
        {
            FlowLayoutPanel panel_Bottom_flowLayout = null;
            if (null == Controls["panel_Bottom_flowLayout"])
            {
                panel_Bottom_flowLayout = new FlowLayoutPanel()
                {
                    AutoSize = true,
                    BackColor = System.Drawing.Color.Transparent,
                    Dock = System.Windows.Forms.DockStyle.Bottom,
                    Location = new System.Drawing.Point(0, 332),
                    Name = "panel_Bottom_flowLayout",
                    Size = new System.Drawing.Size(479, 0),
                    TabIndex = 1
                };
                Controls.Add(panel_Bottom_flowLayout);
            }
            else
            {
                panel_Bottom_flowLayout = (FlowLayoutPanel)Controls["panel_Bottom_flowLayout"];
            }
            Form frm = (Form)Activator.CreateInstance(thisForm);
            const int GWL_STYLE = -16;
            const uint WS_POPUP = 0x80000000;
            const uint WS_CHILD = 0x40000000;
            uint style = GetWindowLong(frm.Handle, GWL_STYLE);
            style = (style & ~(WS_POPUP)) | WS_CHILD;
            SetWindowLong(frm.Handle, GWL_STYLE, style);
            SetParent(frm.Handle, panel_Container.Handle);
            int captionHeight = frm.Height - frm.ClientSize.Height;
            frm.Location = new Point(panel_Container.Width / 2 - frm.Width / 2, panel_Container.Height / 2 - frm.Height / 2 + captionHeight);
            frm.Show();
            frm.MouseDown += (sender, mea) =>
            {
                const int WM_NCLBUTTONDOWN = 0xA1;
                ReleaseCapture();
                PostMessage(frm.Handle, WM_NCLBUTTONDOWN, new IntPtr(2), IntPtr.Zero);
            };
            frm.Resize += (Sendder, rea) =>
            {
                if (frm.WindowState == FormWindowState.Minimized)
                {
                    frm.SendToBack();
                    Label lbl =
                    new Label()
                    {
                        AutoSize = true,
                        Text = frm.Text,
                        BackColor = Color.LightCoral,
                        BorderStyle = BorderStyle.FixedSingle,
                        Padding = new System.Windows.Forms.Padding(5),
                        Margin = new System.Windows.Forms.Padding(2)
                    };
                    lbl.Click += (sender, cea) =>
                    {
                        frm.WindowState = FormWindowState.Normal;
                        frm.Location = lbl.Location;
                        frm.BringToFront();
                        panel_Bottom_flowLayout.Controls.Remove(lbl);
                    };
                    panel_Bottom_flowLayout.Controls.Add(lbl);
                }
            };
        }
