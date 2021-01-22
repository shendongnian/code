    try
    {
        using (FileStream fs = new FileStream(filename, FileMode.Create))
        {
            //FileMode.Create will make sure that if the file allready exists,
            //it is deleted and a new one create. If not, it is created normally.
            using (StreamWriter sw = new StreamWriter(fs))
            {
               //whatever you wanna do.
            }
        }
    }
    catch (Exception e)
    {
        System.Diagnostics.Debug.WriteLine(e.Message);
    }
