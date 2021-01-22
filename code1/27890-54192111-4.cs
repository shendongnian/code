    const string TheProgram = @" ... ";
    Process p = new Process();
    ProcessStartInfo psi = new ProcessStartInfo(TheProgram);
    psi.UseShellExecute = false;
    //psi.CreateNoWindow = true;
    psi.RedirectStandardInput = true;
    psi.RedirectStandardOutput = true;
    p.StartInfo = psi;
    p.Start();
    const string FirstQuestion = "First question: ";
    const string SecondQuestion = "Another question: ";
    const string FinalQuestion = "Final question: ";
    StreamWriter sw = p.StandardInput;
    StreamReader sr = p.StandardOutput;
    string Question;
    StringBuilder sb = new StringBuilder("Executing " + TheProgram + "\r\n");
    Question = await sr.ReadLineAsync();
    if (Question != FirstQuestion)
        return;
    sw.WriteLine("First answer");
    sb.Append(Question + "answered\r\n");
    Question = await sr.ReadLineAsync();
    if (Question != SecondQuestion)
        return;
    sw.WriteLine("Second answer");
    sb.Append(Question + "answered\r\n");
    Question = await sr.ReadLineAsync();
    if (Question != FinalQuestion)
        return;
    sw.WriteLine("Final answer");
    sb.Append(Question + "answered\r\n");
    ResultBox.Text = sb.ToString();
