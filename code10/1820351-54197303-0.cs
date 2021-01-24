    namespace DZEThaitro
    {    
        class Hello 
        {
            static void Main() 
            {
                Mem m = new Mem();
                Mem m = new Mem();
                long pointer = 0xB8DEDC;
                bool procopen = false;
                int OFFSET_skillID = 0xCC;
                //open process you want to write to
                procopen = m.OpenProcess("iPlayRO.exe");
                //check if Process is Open
                if (procopen)
                {
                    //Write Memory
                    m.writeMemory("base+" + pointer + ",0x" + OFFSET_skillID.ToString("X"), "int", skillID.ToString());
                    //Write Multi Level Pointer
                    m.writeMemory("base+" + pointer + ",0xCC,0x2C,0x4C0", "int", skill_Lvl.ToString());
                    
                    //Read Memory
                    int skill_ID = m.readInt("base+" + pointer + ",0x" + OFFSET_skillID.ToString("X"));
                    //Read Multi Level Pointer
                    int skill_Lvl = m.readInt("base+" + pointer + ",0xCC,0x2C,0x4C0");
                    //AOB Scan
                    long address = aobscan("00 01 02 03 04 05 06 07 08 09", true, true);
                    //Write Memory with address from AOB
                    m.writeMemory(address.ToString("X"), "int", "666");
                }
            }
            /// <summary>
            /// AOB Scan the Memory of the Current Open Process.
            /// </summary>
            /// <param name="aob">Array of Byte that you want to Scan for.</param>
            /// <param name="writeable">Is Memory Region Read/Writeable</param>
            /// <param name="executeable">Is Memory Region Executeable</param>
            private async long aobscan(string aob, bool writeable = true, bool executeable = false)
            {                
                if (procopen)
                {
                    long addr = (await m.AoBScan(aob, writeable, executeable)).FirstOrDefault();
                    return addr;
                }
                else
                    return 0;
            }
        }
    }
