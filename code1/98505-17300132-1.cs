            int deltaScroll = 10;
            if (e.Delta > 0)
            {
                
                if (pnlContain.VerticalScroll.Value - deltaScroll >= pnlContain.VerticalScroll.Minimum)
                    pnlContain.VerticalScroll.Value -= deltaScroll;
                else
                    pnlContain.VerticalScroll.Value = pnlContain.VerticalScroll.Minimum;
            }
            else
            {
                if (pnlContain.VerticalScroll.Value + deltaScroll <= pnlContain.VerticalScroll.Maximum)
                    pnlContain.VerticalScroll.Value += deltaScroll;
                else
                    pnlContain.VerticalScroll.Value = pnlContain.VerticalScroll.Maximum;
            }
