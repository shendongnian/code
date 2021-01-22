    public void main() 
    { 
         executeFn("1"); 
         executeFn("2");
    } 
    List<string> QueuedCalls = new List<string>(); // contains the queued items
    bool isRunning = false; // indicates if there is an async operation running
    private bool executeFn(string someval) 
    { 
        if(isRunning) { QueuedCalls.Add(someval); return; } // if there is an operation running, queue the call
        else { isRunning = true; } // if there is not an operation running, then update the isRunning property and run the code
        runSomeAsyncCode(); //undefined async operation here<- 
        isRunning = false; //get here when the async is completed, (updates the app telling it this operation is done)
        if(QueuedCalls.Count != 0)//check if there is anything in the queue
        {
            //there is something in the queue, so remove it from the queue and execute it.
            string val = QueuedCalls[0];
            QueuedCalls.RemoveAt(0);
            executeFn(val);
        }
    } 
