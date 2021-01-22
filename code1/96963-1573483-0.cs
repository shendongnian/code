    class MyForm:Form{
    //...
    protected override void OnLoad(EventArg e){
       this.Cursor=Cursors.Wait();
       this.Enabled=false; 
    
       // do a long running DB operation without blocking the UI Thread
       ThreadPool.QueueUserWorkItem(state=>{
    
         DoLongDBOperation();
    
         // re enable the form
         BeginInvoke(new Action(()=>{ this.Cursor=Cursors.Default;this.Enabled=true;}));
    
       });
    }
