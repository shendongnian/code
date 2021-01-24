        static void Main(string[] args)
        {
            var handle = (IntPtr)0x35087C; // notepad textbox handle
            var prevInfo = default(SCROLLINFO);
            int iterations = 1000;
            while (iterations > 0)
            {
                var curInfo = new SCROLLINFO();
                curInfo.cbSize = Marshal.SizeOf(curInfo);
                curInfo.fMask = (int)ScrollInfoMask.SIF_ALL;
                if (GetScrollInfo(handle, (int)ScrollBarDirection.SB_VERT, ref curInfo))
                {
                    var dir = curInfo.nPos < prevInfo.nPos ? "Up" : "Down";
                    dir = curInfo.nPos == prevInfo.nPos ? "Unchanged" : dir;
                    Console.WriteLine(dir);
                    prevInfo = curInfo;
                }
                else
                {
                    Console.WriteLine($"No scrolling.. {Marshal.GetLastWin32Error()}");
                }
                System.Threading.Thread.Sleep(100);
                iterations--;
            }
            Console.ReadLine();
        }
