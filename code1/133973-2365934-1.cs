    public class PhotoDownload
    {
    	public ManualResetEvent Complete { get; private set; }
    	public Object RequireData { get; private set; }
    	public Object Result { get; private set; }
    }
    
    public void DownloadPhotos()
    {
    	var photos = new List<PhotoDownload>();
         
        // build photo download list
    	foreach (var photo in photos)
    	{
    		ThreadPool.QueueUserWorkItem(DownloadPhoto, photo);
    	}
        // wait for the downloads to complete
    	foreach (var photo in photos)
    	{
    		photo.Complete.WaitOne();
    	}
        // make sure everything happened correctly
    }
    
    public void DownloadPhoto(object state)
    {
    	var photo = state as PhotoDownload;
    	try
    	{
                // do not access fields in this class
                // everything should be inside the photo object
    	}
    	finally
    	{
    		photo.Complete.Set();
    	}
    }
