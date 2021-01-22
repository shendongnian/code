    static void WriteAACData(FileInfo file, int rating, int playcount)
    {
        ShellFile so = ShellFile.FromFilePath(file.FullName);
        uint fileRating = (uint)so.Properties.System.Rating.Value;
        System.Diagnostics.Trace.WriteLine(String.Format("Rating: {0}", fileRating));
        so.Properties.System.Rating.Value = (uint)rating;
    }
