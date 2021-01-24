cs
public static async Task<(Dictionary<string, string> MetaInfo, string Error)> GetMetaInfoAsync_iText7(string path)
{
	try
	{
		var metaInfo = await Task.Run(() =>
		{
			var metaInfoDict = new Dictionary<string, string>();
			using (var pdfReader = new PdfReader(path))
			using (var pdfDocument = new PdfDocument(pdfReader))
			{
				metaInfoDict["PDF.PageCount"] = $"{pdfDocument.GetNumberOfPages():D}";
				metaInfoDict["PDF.Version"] = $"{pdfDocument.GetPdfVersion():D}";
				var pdfTrailer = pdfDocument.GetTrailer();
				var pdfDictInfo = pdfTrailer.GetAsDictionary(PdfName.Info);
				foreach (var pdfEntryPair in pdfDictInfo.EntrySet())
				{
					var key = "PDF." + pdfEntryPair.Key.ToString().Substring(1);
					string value;
					switch (pdfEntryPair.Value)
					{
						case PdfString pdfString:
							value = pdfString.ToUnicodeString();
							break;
						default:
							value = pdfEntryPair.Value.ToString();
							break;
					}
					metaInfoDict[key] = value;
				}
				return metaInfoDict;
			}
		});
		return (metaInfo, null);
	}
	catch (Exception ex)
	{
		var exception = (Exception)Activator.CreateInstance(ex.GetType(), $"{path}", ex);
		LOG.Error(exception);
		if (Debugger.IsAttached) Debugger.Break();
		return (null, ex.Message);
	}
}
