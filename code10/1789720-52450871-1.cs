       string path2 = @"C:\Void\Dump\Dump.txt";
        Process p = new Process();
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = "cmd.exe";
        info.RedirectStandardInput = true;
        info.UseShellExecute = false;
        p.StartInfo = info;
        p.Start();
        StreamWriter sw = p.StandardInput;
        using (sw)
        {
            if (sw.BaseStream.CanWrite)
            {
                sw.WriteLine(@"cd C:\Void\Dump");
                sw.WriteLine(@"strings -s");
                System.IO.StreamWriter stream = new System.IO.StreamWriter(path2);
				  StreamReader reader = new StreamReader(path2);//Fixed this to have the right value
				string text = reader.ReadToEnd();//convert stream to text
				File.WriteAllText(path2, text);
					   
				Console.SetOut(stream);
				sw.AutoFlush = true;
            }
        }
