    private static int GetMemoryAddressOfString(byte[] searchedBytes, Process p)
    {
        //List<int> addrList = new List<int>();
        int addr = 0;
        int speed = 1024*64;
        for (int j = 0x400000; j < 0x7FFFFFFF; j+= speed)
        {
            ManagedWinapi.ProcessMemoryChunk mem = new ProcessMemoryChunk(p, (IntPtr)j, speed + searchedBytes.Length);
            byte[] bigMem = mem.Read();
            
            for (int k = 0; k < bigMem.Length - searchedBytes.Length; k++)
            {
                bool found = true;
                for (int l = 0; l < searchedBytes.Length; l++)
                {
                    if(bigMem[k+l] != searchedBytes[l])
                    {
                        found = false;
                        break;
                    }
                }
                if(found)
                {
                    addr = k+j;
                    break;
                }
            }
            if (addr != 0)
            {
                //addrList.Add(addr);
                //addr = 0;
                break;
            }
        }
        //return addrList;
        return addr;
    }
