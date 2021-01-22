    private static void writePlaylistEntry(Stream playlist, string filename, int length) {
        Encoding utf8= new UTF8Encoding(false);
        Encoding ansi= Encoding.Default;
        playlist.Write(utf8.GetBytes("#EXTINFUTF8:"+length+","+filename+"\n"));
        playlist.Write(ansi.GetBytes("#EXTINF:"+length+","+filename+"\n"));
        playlist.Write(utf8.GetBytes("#UTF8:"+filename+"\n"));
        playlist.Write(ansi.GetBytes(filename+"\n"));
    }
