    static string[] mediaExtensions = {
        ".PNG", ".JPG", ".JPEG", ".BMP", ".GIF", //etc
        ".WAV", ".MID", ".MIDI", ".WMA", ".MP3", ".OGG", ".RMA", //etc
        ".AVI", ".MP4", ".DIVX", ".WMV", //etc
    };
    static bool IsMediaFile(string path) {
        return -1 != Array.IndexOf(mediaExtensions, Path.GetExtension(path).ToUpperInvariant());
    }
