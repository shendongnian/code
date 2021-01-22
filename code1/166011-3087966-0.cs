        protected override void OnFormClosing(FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                this.Hide();
                e.Cancel = true;
            }
        }
