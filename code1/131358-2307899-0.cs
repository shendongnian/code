    public class PartitionedXmlSerializer<TObj>
    {
    	private readonly int _fileSizeLimit;
    
    	public PartitionedXmlSerializer(int fileSizeLimit)
    	{
    		_fileSizeLimit = fileSizeLimit;
    	}
    
    	public void Serialize(string filenameBase, TObj obj)
    	{
    		using (var memoryStream = new MemoryStream())
    		{
    			// serialize the object in the memory stream
    			using (var xmlWriter = XmlWriter.Create(memoryStream))
    				new XmlSerializer(typeof(TObj))
    					.Serialize(xmlWriter, obj);
    
    			memoryStream.Seek(0, SeekOrigin.Begin);
    
    			var extensionFormat = GetExtensionFormat(memoryStream.Length);
    			
    			var buffer = new char[_fileSizeLimit];
    			
    			var i = 0;
    			// split the stream into files
    			using (var streamReader = new StreamReader(memoryStream))
    			{
    				int readLength;
    				while ((readLength = streamReader.Read(buffer, 0, _fileSizeLimit)) > 0)
    				{
    					var filename 
    						= Path.ChangeExtension(filenameBase, 
    							string.Format(extensionFormat, i++));
    					using (var fileStream = new StreamWriter(filename))
    						fileStream.Write(buffer, 0, readLength);
    				}
    			}
    		}
    	}
    
    	/// <summary>
    	/// Gets the a file extension formatter based on the 
    	/// <param name="fileLength">length of the file</param> 
    	/// and the max file length
    	/// </summary>
    	private string GetExtensionFormat(long fileLength)
    	{
    		var numFiles = fileLength / _fileSizeLimit;
    		var extensionLength = Math.Ceiling(Math.Log10(numFiles));
    		var zeros = string.Empty;
    		for (var j = 0; j < extensionLength; j++)
    		{
    			zeros += "0";
    		}
    		return string.Format("xml.part{{0:{0}}}", zeros);
    	}
    }
