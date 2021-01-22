        public static void ShowNotification(string msg) {
            var t = new Thread(() => {
                var frm = new frmNotify(msg);
                frm.TopMost = true;
                var rc = Screen.PrimaryScreen.WorkingArea;
                frm.StartPosition = FormStartPosition.Manual;
                frm.CreateControl();
                frm.Location = new Point(rc.Right - frm.Width, rc.Bottom - frm.Height);
                Application.Run(frm);
            });
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
        }
