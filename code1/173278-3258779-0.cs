    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                ProcessStartInfo si = new ProcessStartInfo();
                si.FileName = "handle.exe";     //name of the handle program from sysinternals
                                                //assumes that its in the exe directory or in your path 
                                                //environment variable
                //the following three lines are required to be able to read the output (StandardOutput)
                //and hide the exe window.
                si.RedirectStandardOutput = true;
                si.WindowStyle = ProcessWindowStyle.Hidden;
                si.UseShellExecute = false;
                si.Arguments = "test.xlsx";     //this is the file you're trying to access that is locked
                
                //these 4 lines create a process object, start it, then read the output to 
                //a new string variable "s"
                Process p = new Process();
                p.StartInfo = si;
                p.Start();
                string s = p.StandardOutput.ReadToEnd();
                //this will use regular expressions to search the output for process name
                //and print it out to the console window
                string regex = @"^\w*\.EXE";
                MatchCollection matches = Regex.Matches(s, regex, RegexOptions.Multiline);
                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
                //this will use regex to search the output for the process id (pid)
                //and print it to the console window.
                regex = @"pid: (?<pid>[0-9]*)";
                matches = Regex.Matches(s, regex, RegexOptions.Multiline);
                foreach (var obj in matches)
                {
                    Match match = (Match)obj;   //i have to cast to a Match object
                                                //to be able to get the named group out
                    Console.WriteLine(match.Groups["pid"].Value.ToString());
                }
                
                Console.Read();
            }
        }
    }
