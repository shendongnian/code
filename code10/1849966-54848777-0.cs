    foreach (Panel pnl in backPanel.Controls)
        {
            foreach (Control c in pnl.Controls)
            {
                ColorSlider.ColorSlider slider = c as ColorSlider.ColorSlider;
                if (slider != null)
                {
                    slider.ThumbInnerColor = Color.FromArgb(99, 130, 208);
                }
            }
        }
