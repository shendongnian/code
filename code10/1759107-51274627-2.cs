        catch(Exception ex)
        {
             //file is being opened.
             Process myProcess = new Process();
             myProcess.EnableRaisingEvents = true;
             myProcess.Exited += new EventHandler(myProcess_Exited);
             myProcess.Start("CMD.exe","taskkill /f /im excel.exe");         
        }
    
    private void myProcess_Exited(object sender, System.EventArgs e)
        {
    
            eventHandled = true;
            File.WriteAllText(saveFileDialog.FileName, sb.ToString());
        }
