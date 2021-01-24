    public bool TryReadConfig(string path, out string[] valores)
    {
        valores = null;
        try {
            valores = read the values;
            return true;
        } catch {
            Display message;
            return false;
        }
    }
