    private double _width;
    private double _height;
    
    public MainPage
    {
       _width = this.Width;
       _height = this.Height;
    }
    
    protected override void OnSizeAllocated( double width, double height )
    {
       if ( _width != width || _height != height )
       {
           _width = width;
           _height = height;
           ScreenSizeChanged( width, height );      
       }
    }
    
    private void ScreenSizeChanged( double newWidth, double newHeight )
    {
        //your logic goes here
    }  
