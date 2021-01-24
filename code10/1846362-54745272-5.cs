c#
using System;
using System.Text;
using System.Runtime.InteropServices;
namespace Testclass
{
    internal class Native
    {
        [DllImport("testlib.dll")]
        internal static extern void free_string(IntPtr str);
        [DllImport("testlib.dll")]
        internal static extern StringHandle result(string inputstr);
    }
    internal class StringHandle : SafeHandle
    {
        public StringHandle() : base(IntPtr.Zero, true) { }
        public override bool IsInvalid
        {
            get { return false; }
        }
        public string AsString()
        {
            int len = 0;
            while (Marshal.ReadByte(handle,len) != 0) { ++len; }
            byte[] buffer = new byte[len];
            Marshal.Copy(handle, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }
        protected override bool ReleaseHandle()
        {
            Native.free_string(handle);
            return true;
        }
    }
    internal class StringTesting: IDisposable
    {
        private StringHandle str;
        private string resString;
        public StringTesting(string word)
        {
            str = Native.result(word);
        }
        public override string ToString()
        {
            if (resString == null)
            {
                resString = str.AsString();
            }
            return resString;
        }
        public void Dispose()
        {
            str.Dispose();
        }
    }
    class Testclass
    {
        public static string Testclass(string inputstr)
        {
            return new StringTesting(inputstr).ToString();
        }
        public static Main()
        {
            Console.WriteLine(new Testclass("Brötchen")); // output: Brötchen 
        }
    }
}
While this archives the desired result, I am still unsure what causes the wrong decoding in the code provided by the question.
  [1]: https://jakegoulding.com/rust-ffi-omnibus/basics/
  [2]: https://crates.io/crates/libc
  [3]: https://doc.rust-lang.org/std/ffi/struct.CString.html
