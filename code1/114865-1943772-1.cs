    public void MoveThatPic(PictureBox picBox, int distance) // New method, 
                                          // takes a variable called Distance.
    {
        MessageBox.Show(distance.ToString()); // Just show us that Variable.
        // I need to be able to access Form1's picture box before I can use this. :(
        Point BoxMovement = picBox.Location; //create a point called BoxMovement
        BoxMovement.X += distance; // Adjust the X of that by distance.
        picBox.Location = BoxMovement; // now adjust the Box by the Point's location.
    }
