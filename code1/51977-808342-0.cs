    class MyPictureBox: IThumbnail
    {
        private _pictureBox = new PictureBox();
        bool Visible     
        { 
            get 
            { 
                return _pictureBox.Visible; 
            } 
            set 
            { 
                _pictureBox.Visible = value; 
            }
        }
        //implement the rest, you get the idea
    }
