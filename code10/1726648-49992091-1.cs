        [DllExport("Command", CallingConvention.StdCall)]
        public static int Command(string commandName, string arguments, IntPtr result, out /*or ref*/ int resultLength)
    {
           string inputStr = Marshal.PtrToStringUni(result); //Unicode
           resultLength = inputStr.Length;
           int x = MainFunc.Command(commandName, arguments, ref inputStr);
           if(null == inputStr)
           {
                inputStr = "";
           }
           if(inputStr.Length > resultLength)
           {
                inputStr = inputStr.Substring(0, resultLength);
            }
            byte[] outputBytes = Encoding.Unicode.GetBytes(inputStr);
            Marshal.Copy(outputBytes, 0, result, outputBytes.Length);
            resultLength = inputStr.Length;
            return x;
        }
