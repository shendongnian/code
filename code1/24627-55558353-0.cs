    private void comboBox_DropDown(object sender, EventArgs e)
            {
                Graphics g = (sender as ComboBox).CreateGraphics();
                float longest = 0;
                for (int i = 0; i < (sender as ComboBox).Items.Count; i++)
                {
                    SizeF textLength = g.MeasureString((sender as ComboBox).Items[i].ToString(), (sender as ComboBox).Font);
     
                    if (textLength.Width > longest)
                        longest = textLength.Width;
                }
     
                if (longest > 0)
                    (sender as ComboBox).DropDownWidth = (int)longest;
            }
