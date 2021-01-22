            int pos = (Container.AutoScrollPosition.Y != 0 ? Container.AutoScrollPosition.Y - newitem.Height : 0);
            if (Container.Controls.Count > 0)
            {
                foreach (Control c in Container.Controls)
                {
                    c.Location = new Point(0, pos);
                    pos += c.Height;
                    }
                }                
            }
            newitem.Location = new Point(0, pos);
            Container.Controls.Add(newitem);
