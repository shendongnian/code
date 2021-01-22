            ProcessStartInfo psi = new ProcessStartInfo(@"c:\temp\testC.exe");
            psi.CreateNoWindow = true;
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            Process p = Process.Start(psi);
            string input = "";
            ConsoleColor fc = Console.ForegroundColor;
            StreamWriter sw = p.StandardInput;
            StreamReader sr = p.StandardOutput;
            char[] buffer = new char[1024];
            int l = 0;
            do
            {
                Console.Write("Enter input: ");
                input = Console.ReadLine();
                int i = Convert.ToInt32(input);
                sw.Write(i);
                sw.Write(sw.NewLine);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(">> ");
                l = sr.Read(buffer, 0, buffer.Length);
                for (int n = 0; n < l; n++)
                    Console.Write(buffer[n] + " ");
                Console.WriteLine();
                Console.ForegroundColor = fc;
            } while (input != "10");
            Console.WriteLine("Excution Finished. Press Enter to close.");
            Console.ReadLine();
            p.Close();
