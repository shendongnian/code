       public static void EnableDynamicLoadingForDlls(Assembly assemblyToLoadFrom, string embeddedResourcePrefix) {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => { // had to add =>
                try {
                    string resName = embeddedResourcePrefix + "." + args.Name.Split(',')[0] + ".dll.resource";
                    using (Stream input = assemblyToLoadFrom.GetManifestResourceStream(resName)) {
                        return input != null
                             ? Assembly.Load(StreamToBytes(input))
                             : null;
                    }
                } catch (Exception ex) {
                    _log.Error("Error dynamically loading dll: " + args.Name, ex);
                    return null;
                }
            }; // Had to add colon
        }
        private static byte[] StreamToBytes(Stream input) {
            int capacity = input.CanSeek ? (int)input.Length : 0;
            using (MemoryStream output = new MemoryStream(capacity)) {
                int readLength;
                byte[] buffer = new byte[4096];
                do {
                    readLength = input.Read(buffer, 0, buffer.Length); // had to change to buffer.Length
                    output.Write(buffer, 0, readLength);
                }
                while (readLength != 0);
                return output.ToArray();
            }
        }
