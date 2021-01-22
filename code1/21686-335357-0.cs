//delegate with same prototype as the method to call asynchrously
delegate void ProcessItemDelegate(object item);
//method to call asynchronously
private void ProcessItem(object item) { ... }
//method in the GUI thread
private void DoWork(object itemToProcess)
{
    //create delegate to call asynchronously...
    ProcessItemDelegate d = new ProcessItemDelegate(this.ProcessItem);
    IAsyncResult result = d.BeginInvoke(itemToProcess,
                                        new AsyncCallback(this.CallBackMethod),
                                        d); 
}
//method called when the async operation has completed
private void CallbackMethod(IAsyncResult ar)
{
    ProcessItemDelegate d = (ProcessItemDelegate)ar.AsyncState;
    //EndInvoke must be called on any delegate called asynchronously!
    d.EndInvoke(ar);
}
