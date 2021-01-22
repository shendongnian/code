            public static void VerticalListLayoutStrategy(Panel panel)
        {
            int top = 0;
            foreach (Control control in panel.Controls)
            {
                control.Location = new Point(0, top);
                control.Width = panel.ClientSize.Width;
                top += control.Height;
            }
        }
