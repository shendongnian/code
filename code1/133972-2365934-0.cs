    public class PhotoDownload
    {
    	public ManualResetEvent Complete { get; private set; }
    	public Object RequireData { get; private set; }
    	public Object Result { get; private set; }
    }
    
    public void DownloadPhotos()
    {
    	var photos = new List<PhotoDownload>();
    	foreach (var photo in photos)
    	{
    		ThreadPool.QueueUserWorkItem(DownloadPhoto, photo);
    	}
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
    		// ...
    	}
    	finally
    	{
    		photo.Complete.Set();
    	}
    }
