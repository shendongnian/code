    using Akka.Actor;
    using Akka.IO;
    using Akka.Streams;
    using Akka.Streams.Dsl;
    using Akka.Streams.IO;
    
    private static Sink<ByteString, Task<IOResult>> FileSink(string filename)
    {
    	return Flow.Create<ByteString>()
    		.ToMaterialized(FileIO.ToFile(new FileInfo(filename), FileMode.Append), Keep.Right);
    }
    
    private async Task Download(string path, Uri uri, long fileStart)
    {
    	using (var system = ActorSystem.Create("system"))
    	using (var materializer = system.Materializer())
    	{
    	   HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
    	   request.AddRange(fileStart);
    
    	   using (WebResponse response = request.GetResponse())
    	   {
    		   Stream stream = response.GetResponseStream();
    
    		   await StreamConverters.FromInputStream(() => stream, chunkSize: 1024)
    			   .RunWith(FileSink(path), materializer);
    	   }
    	}
    }
