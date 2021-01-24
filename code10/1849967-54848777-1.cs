    foreach (Panel pnl in backPanel.Controls)
        {
            foreach (Control c in pnl.Controls)
            {
                if (c is ColorSlider.ColorSlider)
                {
                    (c as ColorSlider.ColorSlider).ThumbInnerColor = Color.FromArgb(99, 130, 208);
                }
            }
        }
