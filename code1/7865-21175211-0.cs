    public string SizeText
    {
        get
        {
            var units = new[] { "B", "KB", "MB", "GB", "TB" };
            var index = 0;
            double size = Size;
            while (size > 1024)
            {
                size /= 1024;
                index++;
            }
            return string.Format("{0:2} {1}", size, units[index]);
        }
    }
