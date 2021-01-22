    public string Execute(string arguments)
        {
            var action = GetProc();
            action.StartInfo.Arguments = arguments;
            action.Start();
            action.WaitForExit();
            return action.StandardOutput.ReadToEnd();
        }
