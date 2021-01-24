    namespace ProvaSalvataggioFile2
    {
        public class TextFile
        {
            public TextFile(string fileName, string contents)
			{
				FileName = fileName;
				Contents = contents;
			}
			public string FileName { get; set; }
			public string Contents { get; set; }
		}
	}
