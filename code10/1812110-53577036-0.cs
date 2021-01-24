        int i = 0;
        void swapLocations()
        {
            foreach(var formObject in objList) //objList == a list or array on all objects you want to move from one container to another
            {
                if (i % 2 == 0)
                {
                    // catch current position             
                    Point moveLocation = new Point(formObject.Location.X + formObject.Parent.Location.X,formObject.Location.Y + formObject.Parent.Location.Y);
                    
                    // remove this object
                    formObject.Parent.Controls.Remove(formObject);
                    // add this object to the form
                    this.Controls.Add(formObject);
                     // set location
                    formObject.Location = moveLocation;
                          
                    formObject.SendToBack();
                }
                else
                {
                    formObject.BringToFront();
                }
            }
            ++i;
        }
