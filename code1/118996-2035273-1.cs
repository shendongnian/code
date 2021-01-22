    string boundary = Guid.NewGuid().ToString();
    string header = string.Format("--{0}", boundary);
    string footer = string.Format("--{0}--", boundary);
    
    StringBuilder contents = new StringBuilder();
    contents.AppendLine(header);
    
    contents.AppendLine(header);
    contents.AppendLine(String.Format("Content-Disposition: form-data; name=\"{0}\"", "username"));
    contents.AppendLine();
    contents.AppendLine("your_username");
    
    contents.AppendLine(header);
    contents.AppendLine(String.Format("Content-Disposition: form-data; name=\"{0}\"", "password"));
    contents.AppendLine();
    contents.AppendLine("your_password");
    
    contents.AppendLine(footer);
