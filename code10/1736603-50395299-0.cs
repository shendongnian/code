    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();
    private void BtnSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            var processInfo = new ProcessStartInfo("cmd.exe")
            {
                UseShellExecute = false,
                RedirectStandardInput = true
            };
            var process = new Process()
            {
                StartInfo = processInfo,
            };
            AllocConsole();
            process.Start(); // This close immediately and not work 
            process.StandardInput.WriteLine("someText");
            process.StandardInput.WriteLine("moreText");
        }
