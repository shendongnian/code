            void clear()
        {
            Zonelbl.Text = "";
            Weightlbl.Text = "";
            Totallbl.Text = "";
            Netlbl.Text = "";
            WeightText.Text = "";
            CAPPEDlbl.Visible = false;
            WeightText.Focus();
        }
        private void ClearButton_Click(object sender, EventArgs e)
    {
        clear();
    }
