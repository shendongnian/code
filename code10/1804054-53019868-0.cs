    private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
              var yourFont = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            if (e.Index == 0)
            {
                e.Graphics.DrawString(comboBox1.Items[e.Index].ToString(), yourFont, Brushes.LightGray, e.Bounds);
            }
            else
            {
                e.DrawBackground();
                e.Graphics.DrawString(comboBox1.Items[e.Index].ToString(), yourFont, Brushes.Black, e.Bounds);
                e.DrawFocusRectangle();
            }
        }
     private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                comboBox1.SelectedIndex = -1;
        }
