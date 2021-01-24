    static Task<string> StartProcess(string proc)
    {
            StringBuilder sb = new StringBuilder();
            Process pr = new Process
            {
                StartInfo = procStartInfo
            };
            var tcs = new TaskCompletionSource<string>();
            pr.Exited += (o, e) =>
            {
                tcs.SetResult(sb.ToString());
                pr.Dispose();
            };
            ....
            return tcs.Task;
    }
