        void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            int left = combo.Width - (SystemInformation.HorizontalScrollBarThumbWidth + SystemInformation.HorizontalResizeBorderThickness);
            if (e.X >= left)
            {
                // They did click the button, so let it happen.
            }
            else
            {
                // They didn't click the button, so prevent the dropdown.
            }
        }
