    public string[] GetPictures() {
        // This method remains unchanged
    }
    
    public string[] GetPictures(int index) {
       // Get the string array from GetPictures
       string[] pictures = GetPictures();
    
       // Return a specific index
       return pictures[index];
    
       // As you can see, this method might be
       // dangerous to use, because someone could
       // ask for an invalid index causing an
       // IndexOutOfRangeException
    }
    HomeWork work = new HomeWork();
    Image1.ImageUrl = work.GetPictures(0);
    Image2.ImageUrl = work.GetPictures(1);
    Image3.ImageUrl = work.GetPictures(2);
