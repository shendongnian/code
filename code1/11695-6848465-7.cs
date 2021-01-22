            // Class variable to keep track of which row is currently selected:
            int hoveredIndex = -1;
            private void lstCars_MouseMove(object sender, MouseEventArgs e)
            {
                // See which row is currently under the mouse:
                int newHoveredIndex = lstCars.IndexFromPoint(e.Location);
                // If the row has changed since last moving the mouse:
                if (hoveredIndex != newHoveredIndex)
                {
                    // Change the variable for the next time we move the mouse:
                    hoveredIndex = newHoveredIndex;
                    // If over a row showing data (rather than blank space):
                    if (hoveredIndex > -1)
                    {
                        //Set tooltip text for the row now under the mouse:
                        tt1.Active = false;
                        tt1.SetToolTip(lstCars, ((Car)lstCars.Items[hoveredIndex]).Info);
                        tt1.Active = true;
                    }
                }
            }
