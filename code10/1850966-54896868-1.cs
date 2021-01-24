    [HttpGet]
	public IActionResult DownloadLog()
	{
		var (path, bytes) = GetThePathAndTheNumberOfBytesIKnowHaveBeenFlushed();
		var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite); // this ensures that the file can be read while it's still being written
		return new PartialFileStreamResult(stream, "text/plain", bytes);
	}
