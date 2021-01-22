    delegate void ProgressDelegate(int Progress);  
    private void UpdateProgress( int  Progress)  
    {  
       if (!progressBar1.Dispatcher.CheckAccess())  
       {  
         progressBar1.Value = Progress;  
       }  
       else  
       {  
         ProgressDelegate progressD = new ProgressDelegate(UpdateProgress);  
         progressBar1.Dispatcher.Invoke(progressD, new object[] { Progress });  
       }  
    }  
