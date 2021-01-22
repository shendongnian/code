        public Icon LoadIconFromExtension(string extension)
        {
            string path = string.Format("dummy{0}", extension);
            using (File.Create(path)) { }
            Icon icon = Icon.ExtractAssociatedIcon(path);
            File.Delete(path);
            return icon;
        }
