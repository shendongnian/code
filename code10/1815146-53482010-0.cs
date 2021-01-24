    @using System
    @implements IDisposable
    
    ...
    
    @functions {
        public void Dispose()
        {
            //anti-pattern work around
            //liveCycle OnUnload don't exists
            save_your_state();
        }
    }
