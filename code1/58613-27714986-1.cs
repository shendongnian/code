    if (File.Exists(path))
    {
        // Is it binary? Check for consecutive nulls..
        byte[] content = File.ReadAllBytes(path);
        for (int i = 1; i < 512 && i < content.Length; i++) {
            if (content[i] == 0x00 && content[i-1] == 0x00) {
                return Convert.ToBase64String(content);
            }
        }
        // No? return text
        return File.ReadAllText(path);
    }
