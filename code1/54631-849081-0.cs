    using (StreamWriter file = File.AppendText("my.log"))
    {
        file.BaseStream.Seek(-"</Errors>".Length, SeekOrigin.End);
        file.Write("   <Error>New error message.</Error></Errors>");
    }
