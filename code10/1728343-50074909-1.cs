    public class BitmapService : IBitmapService
    {
    	private readonly IFileSystem _fileSystem;
    
    	public BitmapService(IFileSystem fileSystem)
    	{
    		_fileSystem = fileSystem;
    	}
    
    	public void SaveBitmapAsPngImage(Uri path, BitmapSource renderBitmap)
    	{
    		// Create a file stream for saving image
    		using (Stream outStream = _fileSystem.OpenOrCreateFileStream(path.LocalPath))
    		{
    			// Use bitmap encoder for our data
    			BitmapEncoder bitmapEncoder = new PngBitmapEncoder();
    			// push the rendered bitmap to it
    			bitmapEncoder.Frames.Add(BitmapFrame.Create(renderBitmap));
    			// save the data to the stream
    			bitmapEncoder.Save(outStream);
    		}
    	}
    }
