        [DllImport("<unknown>", 
               EntryPoint="Generalize", 
               CallingConvention=CallingConvention.StdCall)]
        public static extern int Generalize(int count, IntPtr[] items);
    
        public static void CallGeneralize()
        {
            var itemCount = 3;
            var items = new IntPtr[itemCount];
            
            items[0] = item1; // where itemX is allocated by Marshal.AllocHGlobal(*)
            items[1] = item2;
            items[2] = item3;
            var result = Generalize(itemCount, items);
        }
