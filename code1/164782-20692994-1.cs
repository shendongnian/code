            string assemblyname = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string path = "";
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(assemblyname + ".solutionpath.txt"))
            {
                using (var sr = new StreamReader(stream))
                {
                    path = sr.ReadToEnd().Trim();
                }
            }
