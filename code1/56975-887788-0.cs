    private string GetFrameContent(int arg)
    {
        string filename = (arg == 1) ? "LeftFrame.htm" : "LeftFrameOthers.htm";
        string path = Server.MapPath("./" + filename);
        string content = System.IO.File.ReadAllText(path);
        return content;
    }
    // Populate Literal
    FrameLiteral.Text = GetFrameContent(arg);
