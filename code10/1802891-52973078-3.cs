            memory = MemoryMappedFile.CreateOrOpen("hookFreePIE", 68, MemoryMappedFileAccess.ReadWrite);
            accessor = memory.CreateViewAccessor();
            ewh = EventWaitHandle.OpenExisting("ewhFreePIE");
            :
            :
         // sample of loop   
         public void StartLoop()
        {           
			while (running)
            {
                ewh.WaitOne();// wait Set() of another or same process
                if (cmdtostop) //you could create cmdstop inside memorymapped file (set first byte to 1 for example
                {
                    running = false;
                }
                else
                {
                    //do something with data , using accessor.Read
            }
        }
