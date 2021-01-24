	using (var reader = ExcelReaderFactory.CreateReader(stream)) {
		reader.Read();
		for(int c = 0; c < reader.FieldCount; c += 3) {
			TagListData.Add(new TagClass { IsTagSelected = false, TagName = Convert.ToString(reader.GetValue(c)), rIndex = r, cIndex = c });
		}                    
	}
