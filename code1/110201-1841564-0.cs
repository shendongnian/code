    using (Image img = LoadImageFromDatabase())
    {
    	using (Image resized = ResizeImage(img))
    	{
    		Response.Clear();
    		// Set proper headers
    		using (MemoryStream ms = new MemoryStream())
    		{
    			resized.Save(ms); // maybe the function isn't called Save, can't remember a 100%
    			ms.Seek(0); // Can't remember if this is necessary
    			Response.BinaryWrite(ms);
    		}
    	}
    }
