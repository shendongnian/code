    void HeroMouseEnter(object sender, EventArgs e)
    {
        //My picture box is named Andromeda. I'm going use that name 
        // as a key is a Dictionary and pull the picture according to the name.
        //This is to make a generic event to handle all movements.
        //Any help?
        ((PictureBox)sender).Image =  GetImage(((PictureBox)sender).Name)           
    }
