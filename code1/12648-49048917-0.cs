        private void butPython(object sender, EventArgs e)
        {
            llHello.Text = "Calling Python...";
            this.Refresh();
            Tuple<String,String> python = GoPython(@"C:\Users\BLAH\Desktop\Code\Python\BLAH.py");
            llHello.Text = python.Item1; // Show result.
            if (python.Item2.Length > 0) MessageBox.Show("Sorry, there was an error:" + Environment.NewLine + python.Item2);
        }
        public Tuple<String,String> GoPython(string pythonFile, string moreArgs = "")
        {
            ProcessStartInfo PSI = new ProcessStartInfo();
            PSI.FileName = "py.exe";
            PSI.Arguments = string.Format("\"{0}\" \"{1}\"", pythonFile, moreArgs);
            PSI.CreateNoWindow = true;
            PSI.UseShellExecute = false;
            PSI.RedirectStandardError = true;
            PSI.RedirectStandardOutput = true;
            using (Process process = Process.Start(PSI))
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd(); // Error(s)!!
                    string result = reader.ReadToEnd(); // What we want.
                    return new Tuple<String,String> (result,stderr); 
                }
        }
