    try 
    {
        if(!p.HasExited)
        {
            p.Kill();
        }
        break;
    }
    catch(Exception ex)
    {
        System.Diagnostics.Trace.WriteLine(String.Format("Could not kill process {0}, exception {1}", p.ToString(), ex.ToString()));
    }
 
