    using PX.SM;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Text;
    
    // Create file maintenance graph to load and save file
    UploadFileMaintenance fileGraph = PXGraph.CreateInstance<UploadFileMaintenance>();
    
    // Files are attached to DAC records NoteID fields, get UID (unique identifier) of files
    Guid[] uids = PXNoteAttribute.GetFileNotes(Base.Caches[typeof(DAC)], dacRecord);
    
    if (uids.Length > 0)
    {
    	// Get first file attached to DAC record using UID
    	// Note that FileInfo is part of Acumatica PX.SM namespace and is not .Net FileInfo class
    	FileInfo fileInfo = fileGraph.GetFile(uids[0]);
      
    	if (fileInfo != null)
    	{  
    	   // Converting file raw binary data to a .Net Image object
    	   Image image = ProcessImage(fileInfo.BinData);
    
           // Write converted image to new file.
           // File extension is changed but actual image conversion 
    	   // happens in ConvertImageToByteArray function
     	   const string numberGuidFormat = "N";
     	   const string imageExtension = ".png";
    	   FileInfo newImage = new FileInfo(System.IO.Path.ChangeExtension(Guid.NewGuid().ToString(numberGuidFormat, CultureInfo.InvariantCulture), imageExtension),
    										null,
    										ConvertImageToByteArray(image));
    
           // Save image file in Acumatica										
    	  fileGraph.SaveFile(newImage, FileExistsAction.ThrowException);
    	  
    	  // Attach image file UID to a DAC record note Eield
    	  PXNoteAttribute.SetFileNotes(Base.Caches[typeof(DAC)], dacRecord, newImage.UID.Value);
        }    
    }
    
    public static System.Drawing.Image ProcessImage(byte[] imageData)
    {
    	Bitmap convertedImage = null;
    	
    	try
    	{
    		using (System.IO.MemoryStream stream = new System.IO.MemoryStream(imageData))
    		{
    			Image image = Image.FromStream(stream);
    			convertedImage = new Bitmap(image.Width, image.Height);
    			convertedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    			
    			// Stripping out transparency                               
    			Graphics graphics = Graphics.FromImage(convertedImage);
    			graphics.Clear(Color.White);
    			graphics.DrawImageUnscaled(image, 0, 0);
    		}
    	}
    	catch
    	{
    		// Not a valid image
    	}
    
    	return convertedImage;
    }
    
    
    public static byte[] ConvertImageToByteArray(Image image)
    {
    	using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
    	{
    		// Setting the target format here, I used PNG but you can change it to BMP or JPG
    		image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
    		return stream.ToArray();
    	}
    }
