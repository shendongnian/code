    public ActionResult TESTSAVE()
		{
			var data = "YourDataHere";
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
			var output = new FileContentResult(bytes, "application/octet-stream");
			output.FileDownloadName = "download.txt";
			return output;
		}
