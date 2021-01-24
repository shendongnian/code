    var sb = new StringBuilder();
    for(int index = 1; index <= 20; index++)
    {
        var tb = (TextBox)this.Controls.Find($"X{index}TB", true).FirstOrDefault;
        sb.AppendLine(tb.Text);
    }
    
    // Save the contents of the file.
    var write = new StreamWriter(File.Create(save.FileName));
    write.Write(sb.ToString());
