        [DllImport("extIO_IC7610.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.I1)] 
        public unsafe static extern bool InitHW(StringBuilder name,  StringBuilder model, int* type);
    unsafe void Initialize()
    {
               bool result;
                int type = 0;
                var name = new StringBuilder(250);
                var model = new StringBuilder(250);
                result = InitHW(name, model, &type);
                string _name = name.ToString();
                string _model = model.ToString();
   }
