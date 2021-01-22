       private void EnableDynamicLoadingForDlls() { // This gets called during my program startup
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => { // had to add => here
                var resName = EMBEDDED_RESOURCE_PREFIX + "."; // EMBEDDED_RESOURCE_PREFIX is a string with the namespace my resources get stored in
                resName += args.Name.Split(',')[0] + ".dll.resource"; // I save my embedded resources with the name dllname.dll.resource
                
                var thisAssembly = Assembly.GetExecutingAssembly();
                using (var input = thisAssembly.GetManifestResourceStream(resName)) {
                    return input != null
                         ? Assembly.Load(StreamToBytes(input))
                         : null;
                }
            }; // Had to add semi-colon here
        }
        static byte[] StreamToBytes(Stream input) {
  
                var capacity = input.CanSeek ? (int)input.Length : 0;
                using (var output = new MemoryStream(capacity)) {
                    int readLength;
                    var buffer = new byte[4096];
                    do {
                        readLength = input.Read(buffer, 0, buffer.Length); // had to change to buffer.Length here
                        output.Write(buffer, 0, readLength);
                    }
                    while (readLength != 0);
                    return output.ToArray();
                }
        }
