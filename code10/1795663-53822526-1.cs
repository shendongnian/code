    public static class FileUtil
    {
        public static Task SaveAs(string filename, byte[] data)
            => JSRuntime.Current.InvokeAsync<object>(
                "saveAsFile",
                filename,
                Convert.ToBase64String(data));
    }
