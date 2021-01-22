    using System;
    
    class DisposableClass : IDisposable
    {
        // A name to keep track of the object.
        public string Name = "";
        
        // Free managed and unmanaged resources.
        public void Dispose()
        {
    
            FreeResources(true);
        }
        
        // Destructor to clean up unmanaged resources
        // but not managed resources.
        ~DisposableClass()
        {
            FreeResources(false);
        }
        
        // Keep track if whether resources are already freed.
        private bool ResourcesAreFreed = false;
        
        // Free resources.
        private void FreeResources(bool freeManagedResources)
        {
            Console.WriteLine(Name + ": FreeResources");
            if (!ResourcesAreFreed)
            {
                // Dispose of managed resources if appropriate.
                if (freeManagedResources)
                {
                    // Dispose of managed resources here.
                    Console.WriteLine(Name + ": Dispose of managed resources");
                }
               
                // Dispose of unmanaged resources here.
                Console.WriteLine(Name + ": Dispose of unmanaged resources");
               
                // Remember that we have disposed of resources.
                ResourcesAreFreed = true;
                
                // We don't need the destructor because
                // our resources are already freed.
                GC.SuppressFinalize(this);
            }
        }
    }
