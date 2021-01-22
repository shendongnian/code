    private readonly Queue<object> _Queue = new Queue<object>();
    private readonly object _Lock = new object();
    
    void FillQueue()
    {
        while (true)
        {
            var dbData = new { Found = true, Data = new object() };
            if (dbData.Found)
            {
                lock (_Lock)
                {
                    _Queue.Enqueue(dbData.Data);
                }
            } 
            
            Thread.Sleep(1);
        }       
    }
    
    void ProcessQueue()
    {
        object data = null;
        
        while (true)
        {
            lock (_Lock)
            {
                data = _Queue.Count > 0 ? _Queue.Dequeue() : null;
            }
    
            if (data == null)
            {
                Thread.Sleep(1);
            }
            else
            {
                // Proccess
            }         
        }        
    }
