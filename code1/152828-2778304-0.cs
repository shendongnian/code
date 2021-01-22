            try
            {
                using (StreamWriter sw = new StreamWriter(filepath, false))
                {
                    sw.Write(contents);
                }
            }
            catch (System.IO.IOException exception)
            {
                if (!FileUtil.IsExceptionSharingViolation(exception))
                    throw;
            }
...
        public static bool IsExceptionSharingViolation(IOException exception)
        {
            Type type = typeof(Exception);
            PropertyInfo pinfo = type.GetProperty("HResult", BindingFlags.NonPublic | BindingFlags.Instance);
            uint hresult = (uint)(int)pinfo.GetValue(exception, null);
            //ERROR_SHARING_VIOLATION = 32
            //being an HRESULT adds the 0x8007
            return hresult == 0x80070020;
        }
