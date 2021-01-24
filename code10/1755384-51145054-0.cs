     string line;
            if (!File.Exists(logFile))
            {
                viewLog.Text = "Play";
                alertTB.ForeColor = Color.Red;
                alertTB.Text = "File Does Not Exist | Log Data To Create File";
                chart.Text = "Scope On";
            }
            if (File.Exists(logFile))
            {
                var lineCount = File.ReadLines(logFile).Count();//read text file line count to establish length for array
                if (lineCount < 2)
                {
                    viewLog.Text = "Play";
                    alertTB.ForeColor = Color.Red;
                    alertTB.Text = "File Exists | No Data Has Been Recorded";
                    chart.Text = "Scope On";
                }
                if (counter < lineCount && lineCount > 0)//if counter is less than lineCount keep reading lines
                {
                    line = File.ReadAllLines(logFile).Skip(counter).Take(lineCount).First();
                    string[] dataLog = line.Split(new[] { ',' }, StringSplitOptions.None);
                    //-----------------------------------------Handling my data 
                    counter++;
                }
                else
                {
                    counter = 0;
                    timer2.Enabled = false;
                }
            }
