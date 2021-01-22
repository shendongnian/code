    string content;
    StreamReader sr = null;
    try {
        File.OpenText(path);
        content = sr.ReadToEnd();
    }
    finally {
        if (sr != null) {
            sr.Close();
        }
    }
