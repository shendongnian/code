	public void WritePDF(string filename, IEnumerable<RecordType> records, int rowsPerPage = 5)
	{
		using (var file = CreatePDFFile(filename))
		{
			foreach (var batch in records.Batch(rowsPerPage))
				WritePDFPage(batch);
		}
	}
