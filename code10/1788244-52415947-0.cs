    static void Main(string[] args)
    {
        var pro = new Process();
    
        pro.StartInfo.FileName = @"mybat.bat";
        pro.StartInfo.UseShellExecute = false;
        pro.StartInfo.RedirectStandardInput = true;
        pro.StartInfo.RedirectStandardOutput = true;
        pro.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
    
        pro.Start();
        pro.BeginOutputReadLine();
    
        pro.StandardInput.WriteLineAsync("my input 1").Wait();
        pro.StandardInput.WriteLineAsync("my input 2").Wait();
        pro.StandardInput.WriteLineAsync("my input 3").Wait();
    
        pro.StandardInput.Close();
        pro.WaitForExit();
    }
