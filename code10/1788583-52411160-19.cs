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
    Image framedImage = new FramedImage(originalImage);
    Image toRender = originalImage;
    toRender.Render() // Renders the original image
    toRender = framedImage;
    toRender.Render(); // Renders the original image in a frame
