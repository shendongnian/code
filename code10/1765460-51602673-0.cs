    class Test
    {
        // Make constructor private so no-one can create it
        private Test()
        { }
        // Simple string properties that can't be async
        public string Text1 { get; private set; }
        public string Text2 { get; private set; }
        // Async factory method that can do async things
        public static async Task<Test> CreateAsync()
        {
            var result = new Test();
            result.Text1 = await LoadFile("file1.txt");
            result.Text2 = await LoadFile("file2.txt");
            return result;
        }
        // Helper function
        static async Task<string> LoadFile(string filename)
        {
            var file = await Package.Current.InstalledLocation.GetFileAsync(filename);
            var size = (await file.GetBasicPropertiesAsync()).Size;
            var reader = new DataReader(await file.OpenReadAsync());
            reader.UnicodeEncoding = UnicodeEncoding.Utf8;
            await reader.LoadAsync((uint)size);
            // assumes single-byte UTF codepoints, eg ASCII
            return reader.ReadString((uint)size);
        }
    }
