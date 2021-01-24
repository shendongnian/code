        using System.IO;
        ...
        public static class MyExtensionClass
        {
            public static void Write(this FileStream fs, object value)
            {
                byte[] info = new UTF8Encoding(true).GetBytes(value + "");
                fs.Write(info, 0, info.Length);
            }
            public static void WriteLine(this FileStream fs, object value = null)
            {
                fs.Write(value + "\r\n");
            }
        }
