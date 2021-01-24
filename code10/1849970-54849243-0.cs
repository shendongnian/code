            foreach(Panel pnl in backPanel.Controls.OfType<Panel>())
            {
                foreach(ColorSlider cs in pnl.Controls.OfType<ColorSlider>())
                {
                    cs.ThumbInnerColor = Color.FromArgb(99, 130, 208);
                }
            }
