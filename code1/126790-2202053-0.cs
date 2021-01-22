    static void Main(string[] args)
        {
            object test;
            AppDomain.CurrentDomain.AssemblyResolve += domain_AssemblyResolve;
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "select top 1 Data_Blob from dbo.Serialized";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    var blob = (byte[])cmd.ExecuteScalar();
                    var bf = new BinaryFormatter();
                    var stream = new MemoryStream(blob);
                    bf.AssemblyFormat = FormatterAssemblyStyle.Full;
                    test = bf.Deserialize(stream);
                }
            }
            var objNewVersion = Activator.CreateInstance(Type.GetType("ObjectGraphLibrary.Test, ObjectGraphLibrary, Version=1.0.0.10, Culture=neutral, PublicKeyToken=33c7c38cf0d65826"));
            var oldType = test.GetType();
            var newType = objNewVersion.GetType();
            var oldName = (string) oldType.GetProperty("Name").GetValue(test, null);
            var oldAge = (int) oldType.GetProperty("Age").GetValue(test, null);
            newType.GetProperty("Name").SetValue(objNewVersion, oldName, null);
            newType.GetProperty("DateOfBirth").SetValue(objNewVersion, DateTime.Now.AddYears(-oldAge), null);
            Console.Read();
        }
        static Assembly domain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assName = new AssemblyName(args.Name);
            var uriBuilder = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
            var assemblyPath = Uri.UnescapeDataString(uriBuilder.Path);
            var codeBase = Path.GetDirectoryName(assemblyPath);
            var assPath = Path.Combine(codeBase, string.Format("old\\{0}.{1}.{2}.{3}\\{4}.dll", assName.Version.Major,
                                                     assName.Version.Minor, assName.Version.Build,
                                                     assName.Version.Revision, assName.Name));
            return File.Exists(assPath) ? Assembly.LoadFile(assPath) : null;
        }
