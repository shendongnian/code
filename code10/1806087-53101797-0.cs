        void rdo_HEX_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_HEX.Checked)
            {
                try
                {
                    textbox1.Text = AsciiToHex(textbox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    rdo_HEX.Checked = false;
                }
            }
            else
            {
                try
                {
                    textbox1.Text = HexToAscii(textbox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
