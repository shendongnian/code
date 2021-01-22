    private Bitmap _bitmap;
    public void foo()
    {
    	lock (_bitmap)
    	{
    		BitmapData data;
    		try
    		{
    			data = _bitmap.LockBits(area, ImageLockMOde.ReadOnly, pixelFormat);
    			UseBitmapData(data);
    		}
    		finally
    		{
    			_bitmap.UnlockBits(data);
    		}
    	}
    }
