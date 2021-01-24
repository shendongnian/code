     class Image 
     {
    	void Render() { /*  */ }
     }
     
     class FramedImage : Image 
     { 
    	private Image _originalImage;
    	public FramedImage(Image original) => _originalImage = original;
    	
    	new public void Render()
    	{
    		/* code to render a frame */
    		_originalImage.Render();
    	}
     }
    Image originalImage = new Image();
    Image i = new FramedImage(originalImage);
    i.Render();
