    using TGASharpLib;
    ...
    private void ConvertButton_Click(object sender, EventArgs e)
    {
        var tga = new TGA(@"filepath.cover.png");
        tga.Save(@"filepath.cover.tga");        
    }
