    private Image GetNextImage()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(currentImageIndex < nextImage.Length)
            {
                newImage = nextImage[currentImageIndex++];
                newImage.enabled = true;
            } 
            else
            {
                LoadNextScene();
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(currentImageIndex > 0)
            {
            newImage = nextImage[currentImageIndex--];  
            newImage.enabled = false;                     
            }
            else
            {
            LoadPreviousScene();
            }
        } 
        return newImage;
    }
