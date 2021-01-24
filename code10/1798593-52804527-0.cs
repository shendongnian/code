    try
    {
        // To copy a file to another location and 
        // overwrite the destination file if it already exists.
        System.IO.File.Move(sourceFile, destFile, true);
    }
    catch (Exception ex)
    {
        //show error message using appropriate method for 
        //Console Application
        Console.WriteLine(ex.Message);
        //OR Web Application //
        Response.Write(ex.Message);
        //OR WinForms Application
        MessageBox.Show(ex.Message);
    }
