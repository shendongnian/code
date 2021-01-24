    foreach (Panel pnl in backPanel.Controls)
        {
            foreach (Control c in pnl.Controls)
            {
                if (c is ColorSlider.ColorSlider)
                {
                    ((ColorSlider.ColorSlider)c).ThumbInnerColor = Color.FromArgb(99, 130, 208);
                }
            }
        }
