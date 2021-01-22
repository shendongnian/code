    Form f1 = new YourForm();
    IDispoable f2 = new YourForm();
    
    f1.Dispose(); //call to public void Dispose()
    f2.Dispose(); //call to void IDisposable.Dispose()
