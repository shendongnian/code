    public string CheckFile(file)
    {
        string result="";
        try
        {
            System.Drawing.Image imgInput = System.Drawing.Image.FromFile(file);
            System.Drawing.Graphics gInput = System.Drawing.Graphics.fromimage(imgInput);  
            Imaging.ImageFormat thisFormat = imgInput.RawFormat;   
            result="It is image";        
        }
        catch(Exception ex)
        {
            result="It is not image"; 
        }
        return result;
    }
