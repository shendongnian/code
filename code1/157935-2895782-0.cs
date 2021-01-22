	//Get the file data
	byte[] fileBytes = Artifacts.Provider.GetArtifact(ArtifactInfo.Id);
	//Configure the response header and submit the file data to the response stream.
	HttpContext.Current.Response.AddHeader("Content-disposition", "attachment;filename=" + "myDynamicFileName.txt");
	HttpContext.Current.Response.ContentType = "application/octet-stream";
	HttpContext.Current.Response.BinaryWrite(fileBytes);
	HttpContext.Current.Response.End();
