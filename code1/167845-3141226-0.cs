    public class SampleFileType : FileType
    {
    	public SampleFileType() : base ("Sample file type", FileTypeFlags.SupportsSaving |
    							    FileTypeFlags.SupportsLoading,
    							    new string[] { ".sample" })
    	{
    
    	}
    
    	protected override void OnSave(Document input, System.IO.Stream output, SaveConfigToken token, Surface scratchSurface, ProgressEventHandler callback)
        {
    	    //Here you get the image from Paint.NET and you'll have to convert it
            //and write the resulting bytes to the output stream (this will save it to the specified file)
    
    	    using (RenderArgs ra = new RenderArgs(new Surface(input.Size)))
            {
    	        //You must call this to prepare the bitmap
                        input.Render(ra);
                                 
    	        //Now you can access the bitmap and perform some logic on it
    	        //In this case I'm converting the bitmap to something else (byte[])
                var sampleData = ConvertBitmapToSampleFormat(ra.Bitmap);
                 
                output.Write(sampleData, 0, sampleData.Length);                
            }
    	}
    
    	protected override Document OnLoad(System.IO.Stream input)
        {
    	    //Input is the binary data from the file
            //What you need to do here is convert that date to a valid instance of System.Drawing.Bitmap
            //In the end you need to return it by Document.FromImage(bitmap)
    
    		//The ConvertFromFileToBitmap, just like the ConvertBitmapSampleFormat,
            //is simply a function which takes the binary data and converts it to a valid instance of System.Drawing.Bitmap
            //You will have to define a function like this which does whatever you want to the data
    
            using(var bitmap = ConvertFromFileToBitmap(input))
    		{
    			return Document.FromImage(bitmap);
    		}
        }
    }
