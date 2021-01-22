    public static class SybaseResourceExtractor {
        public static void ExtractSybaseDependencies() {
            ExtractSybaseDependency("QueryLibrary.Unmanaged.sybdrvado20.dll", "sybdrvado20.dll");
            ExtractSybaseDependency("QueryLibrary.Unmanaged.msvcr80.dll", "msvcr80.dll");
            ExtractSybaseDependency("QueryLibrary.Unmanaged.sybcsi_certicom_fips26.dll", "sybcsi_certicom_fips26.dll");
            ExtractSybaseDependency("QueryLibrary.Unmanaged.sybcsi_core26.dll", "sybcsi_core26.dll");
            ExtractSybaseDependency("QueryLibrary.Unmanaged.sbgse2.dll", "sbgse2.dll");
        }
        /// <summary>
        /// Extracts a resource to a file.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <param name="filename">The filename including absolute path.</param>
        static void ExtractSybaseDependency(string resourceName, string filename) {
            try {
                var assembly = Assembly.GetAssembly(typeof(AseConnection));
                var executingAssembly = Assembly.GetExecutingAssembly();
                filename = Path.GetDirectoryName(assembly.Location) + "\\" + filename;
                if (File.Exists(filename)) {
                    File.Delete(filename);    
                }
                if (!File.Exists(filename)) {
                    using (Stream s = executingAssembly.GetManifestResourceStream(resourceName)) {
                        using (var fs = new FileStream(filename, FileMode.Create)) {
                            if (s == null) {
                                throw new Exception("Failed to get resource stream for " + resourceName);
                            }
                            var b = new byte[s.Length];
                            s.Read(b, 0, b.Length);
                            fs.Write(b, 0, b.Length);
                        }
                    }
                }
            } catch {
                //Doing nothing
            }
        }
