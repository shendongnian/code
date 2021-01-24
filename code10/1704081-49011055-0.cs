    using RGiesecke.DllExport;
    using System;
    using System.Runtime.InteropServices;
    
    namespace MyLibrary
    {
        [ComVisible(true)]
        [Guid("8871C5E0-B296-4AB8-AEE7-F2553BACB730"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ISample
        {
            [return: MarshalAs(UnmanagedType.BStr)]
            string GetText();
            void SetText([MarshalAs(UnmanagedType.BStr)]string value);
            [return: MarshalAs(UnmanagedType.BStr)]
            string TestMethod();
        }
        public class Sample : ISample
        {
            public string Text { get; set; }
            public string GetText()
            {
                return Text;
            }
            public void SetText(string value)
            {
                Text = value;
            }
            public string TestMethod()
            {
                return Text + "...";
            }
        }
        public static class UnmanagedExports
        {
            [DllExport(CallingConvention = CallingConvention.StdCall)]
            public static void CreateSampleInstance([MarshalAs(UnmanagedType.Interface)] out ISample instance)
            {
                instance = null;
                try
                {
                    instance =  new Sample { Text = "Hello, world" };
                }
                catch
                {
                }
            }
        }
    }
