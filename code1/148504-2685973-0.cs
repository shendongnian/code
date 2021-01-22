    var playList = new StreamWriter(playlist, false, Encoding.Default);
    playList.WriteLine("#EXTM3U");
    foreach (string track in tracks)
    {
        // Read ID3 tags from file
        var info = new FileProperties(track);
        // Write extended info (#EXTINF:<time>,<artist> - <title>
        if (Encoding.UTF8.GetBytes(info.Artist).Length != info.Artist.Length ||
            Encoding.UTF8.GetBytes(info.Title).Length != info.Title.Length)
        {
            playList.Close();
            playList = new StreamWriter(playlist, true, Encoding.UTF8);
            playList.WriteLine(string.Format("#EXTINFUTF8:{0},{1} - {2}",
                               info.Duration, info.Artist, info.Title));
            playList.Close();
            playList = new StreamWriter(playlist, true, Encoding.Default);
        }
        playList.WriteLine(string.Format("#EXTINF:{0},{1} - {2}",
                           info.Duration, info.Artist, info.Title));
        // Write the name of the file (removing the drive letter)
        string file = Path.GetFileName(track);
        if (Encoding.UTF8.GetBytes(file).Length != file.Length)
        {
            playList.Close();
            playList = new StreamWriter(playlist, true, Encoding.UTF8);
            playList.WriteLine(string.Format("#UTF8:{0}", file));
            playList.Close();
            playList = new StreamWriter(playlist, true, Encoding.Default);
        }
        playList.WriteLine(file);
    }
    playList.Close();
