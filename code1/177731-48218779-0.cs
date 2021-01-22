    Rectangle r = new Rectangle();
            foreach (Screen s in Screen.AllScreens)
            {
                if (s != Screen.FromControl(this)) // Blackout only the secondary screens
                    r = Rectangle.Union(r, s.Bounds);
            }
            
            this.Top = r.Top;
            this.Left = r.Left;
            this.Width = r.Width;
            this.Height = r.Height;
