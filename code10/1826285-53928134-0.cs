    try
    {
     System.GC.Collect(); 
     System.GC.WaitForPendingFinalizers(); 
     System.IO.File.Delete(fullImagePath);
    }
    catch(Exception e){
    }
