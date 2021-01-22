    class Utils
    {
        internal static void copy_dir(string source, string dest)
        {
            if (String.IsNullOrEmpty(source) || String.IsNullOrEmpty(dest)) return;
            Directory.CreateDirectory(dest);
            foreach (string fn in Directory.GetFiles(source))
            {
                File.Copy(fn, Path.Combine(dest, Path.GetFileName(fn)), true);
            }
            foreach (string dir_fn in Directory.GetDirectories(source))
            {
                copy_dir(dir_fn, Path.Combine(dest, Path.GetFileName(dir_fn)));
            }
        }
    }
