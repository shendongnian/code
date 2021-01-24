	public async Task<IActionResult> PostMe() {
		try {
			using (var reader = new StreamReader(Request.Body, Encoding.UTF8)) {
				var serializer = new XmlSerializer(typeof(XmlDocument));
				var objectToParse = (XmlDocument) serializer.Deserialize(reader);
				var pdfFileLocation = await _service.ParseObject(objectToParse);
				
				var file = System.IO.File.ReadAllBytes(pdfFileLocation);
				
				// creates the FileActionResult
				return File(file, "application/pdf", "my_file.pdf");
			}
		} catch (Exception e) {
			return BadRequest();
		}
	}
