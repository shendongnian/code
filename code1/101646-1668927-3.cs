        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.FormOwnerClosing)
            {
                MessageBox.Show("Nice try, but I don't think so...");
                e.Cancel = true;
                return;
            }
            base.OnFormClosing(e);
        }
