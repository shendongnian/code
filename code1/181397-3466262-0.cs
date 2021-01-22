      class Program
      {
        static Dictionary<string, string> typeImages = null;
    
        static string GetImagePath(string type)
        {
          if (typeImages == null)
          {
            typeImages = new Dictionary<string, string>();
            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(appPath, @"image/");
            foreach (string file in Directory.GetFiles(path))
            {
              typeImages.Add(Path.GetFileNameWithoutExtension(file).ToUpper(), Path.GetFullPath(file));
            }
          }
    
          if (typeImages.ContainsKey(type))
            return typeImages[type];
          else
            return typeImages["OTHER"];
        }
    
        static void Main(string[] args)
        {
          Console.WriteLine("File for XLS="+GetImagePath("XLS"));
          Console.WriteLine("File for ZZZ=" + GetImagePath("ZZZ"));
          Console.ReadKey();
        }
      }
