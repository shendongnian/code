    for (int i = 0; i < files.Count; i++) {
		byte[] fileData = null;
		UploadedFile uf = null;
		try {
			if (acceptedFiletypes.Contains(files[i].ContentType)) {
				using (var binaryReader = new BinaryReader(files[i].InputStream)) {
					fileData = binaryReader.ReadBytes(files[i].ContentLength);
				}
				if (fileData.Length > 0) {
					uf = new UploadedFile {
						FileName = files[i].FileName,
						FileType = fileType,
						FileData = fileData
					};
				}
			}
		}
		catch { }
		if (uf != null) {
			projectData.UploadedFiles.Add(uf);
		}
    }
