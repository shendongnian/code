        private void EditCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.ProcessTabKey(true);
            }
            if (e.KeyCode == Keys.Up)
            {
                this.ProcessTabKey(false); // False Indicates backwards
            }
        }
