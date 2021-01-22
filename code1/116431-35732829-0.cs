            if (e.KeyCode == Keys.Enter)
            {
                string trimText;
                trimText = this.txtEntry.Text.Replace("\r\n", "").ToString();
                this.txtEntry.Text = trimText;
                btnEnter.PerformClick();
            }
        }
