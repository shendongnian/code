    static void WriteAllText(string path, string txt) {
        var bytes = Encoding.UTF8.GetBytes(txt);
        using (var f = File.OpenWrite(path)) {
            f.Write(bytes, 0, bytes.Length);
        }
    }
