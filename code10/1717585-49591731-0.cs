        int i = 0;
        void moveout()
        {          
            if (i % 2 == 0)
            {
                // if the control is in a container control
                if (picturebox.Parent.Name!= this.Name)
                {          
                    Point moveLocation = new Point(picturebox.Location.X + picturebox.Parent.Location.X,                                                              picturebox.Location.Y + picturebox.Parent.Location.Y);
                    // remove the control first
                    picturebox.Parent.Controls.Remove(picturebox);
                    this.Controls.Add(picturebox);
                    picturebox.Location = moveLocation;
                }       
                picturebox.SendToBack();
            }
            else
            {
                picturebox.BringToFront();
            }
        ++i;
        }
