            void BackGroundColorArrangerBase(int z) 
            {
               Panel panel = new Panel();
               panel.ID = z.ToString(); //this wil generate the same id for the same pair of colors
               panel.Width = 150;
               panel.Height = 50;
               panel.BackColor = Color.FromArgb(z);
               this.Controls.Add(panel);
            }
