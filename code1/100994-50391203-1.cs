        public class ExRichText : RichTextBox
        {
            [DllImport("kernel32.dll", EntryPoint = "LoadLibraryW",
                       CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern IntPtr LoadLibraryW(string s_File);
            protected override CreateParams CreateParams
            {
                get
                {
                    var cp = base.CreateParams;
                    LoadLibraryW("MsftEdit.dll");
                    cp.ClassName = "RichEdit50W";
                    return cp;
                }
            }
        }
