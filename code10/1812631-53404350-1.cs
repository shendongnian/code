    // Add "using System.Diagnostics;"
    private void button2_Click(object sender, EventArgs e)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = @"D:\Projects\Test_Fixture\Test_Fixture_Visual_Studio\SmartRF Tools\Flash Programmer 2\bin\srfprog.exe";
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardInput = true;
        startInfo.RedirectStandardError = true;
        Process process = new Process();
        process.StartInfo = startInfo;
        process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
        process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.StandardInput.WriteLine("srfprog -t soc(COM84,CC2650) -e -p -v -f c:\test.bin");
        process.WaitForExit();
    }
    static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine) 
    {
        Console.WriteLine(outLine.Data);
    }
