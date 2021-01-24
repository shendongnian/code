    using System.IO;
    using System.Text;
    using System.Collections.Generic;
	public void Main()
	{
        try
        {
            String InputFilePath = Dts.Variables["User::FilePath"].Value.ToString();
            string InputFolder = Path.GetDirectoryName(InputFilePath);
            string TrailerLine = "TotalRow";
            bool FirstFile = true;
            string line;
            List<string> FirstFileLines, SecondFileLines;
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(InputFilePath);
            FirstFileLines = new List<string>();
            SecondFileLines = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(TrailerLine))
                {
                    FirstFile = false;
                    continue;
                }
                if (FirstFile) FirstFileLines.Add(line);
                else SecondFileLines.Add(line);
            }
            File.WriteAllLines(InputFolder + @"\FirstFile.txt", FirstFileLines.ToArray());
            File.WriteAllLines(InputFolder + @"\SecondFile.txt", SecondFileLines.ToArray());
            file.Close();
		    Dts.TaskResult = (int)ScriptResults.Success;
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
            Dts.TaskResult = (int)ScriptResults.Failure;
        }
	}
