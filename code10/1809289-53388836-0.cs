      class Program
          {
              static void Main(string[] args)
              {
                  Program p = new Program();
                  p.butPython();
              }
          public void butPython()
          {
              var hello = "Calling Python...";
              Tuple<String, String> python = GoPython(@"C:\Users\HP\PycharmProjects\final_face\final.py");
              hello = python.Item1; // Show result.
              Console.WriteLine(hello);
              Console.ReadLine();
          }
          public Tuple<String, String> GoPython(string pythonFile, string moreArgs = "")
          {
              ProcessStartInfo PSI = new ProcessStartInfo();
              PSI.FileName = "py.exe";
              PSI.Arguments = string.Format("\"{0}\" {1}", pythonFile, moreArgs);
              PSI.CreateNoWindow = true;
              PSI.UseShellExecute = false;
              PSI.RedirectStandardError = true;
              PSI.RedirectStandardOutput = true;
              using (Process process = Process.Start(PSI))
              using (StreamReader reader = process.StandardOutput)
              {
                  string stderr = process.StandardError.ReadToEnd(); // Error(s)!!
                  string result = reader.ReadToEnd(); // What we want.
                  return new Tuple<String, String>(result, stderr);
              }
          }
      }
