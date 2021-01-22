    // Source:
    // http://www.dotnetjunkies.com/WebLog/johnwood/archive/2006/07/04/transparent_richtextbox.aspx
     
    // It seems there are 4 versions of the RichEdit control out there - when I'm talking about the 
    // RichEdit control, I'm talking about the C DLL that either comes with Windows or some version 
    // of Office. The files are named either RICHEDXX.DLL (XX is the version number), or MSFTEDIT.DLL 
    // and they're in the System32 folder.
     
    // .Net RichTextBox control is bound to version 2. The biggest problem with this version (at least 
    // for me) is that it does not render properly if you try to make the window transparent. Later versions, 
    // however, do.
     
    // We can fix that. If you create a control deriving from the original RichTextBox control, but overriding 
    // the CreateParams property, you can put in a new Windows class name (this is the window class name, 
    // nothing to do with classes in the C# sense). This effectively gives us a free upgrade. When the .Net 
    // RichTextBox control instantiates, it will now use the latest RichEdit control and not the old, archaic, 
    // version 2.
     
    // There are other benefits too - version 3 and beyond of the RichEdit control support quite an extensive 
    // array of layout features, such as tables and full text justification. This is the version of the RichEdit 
    // that WordPad uses in Windows XP. To really see what it's capable of displaying you can create documents in 
    // Word and save them in RTF, load these into the new RichEdit and in a lot of cases it'll look identical, 
    // it's that powerful. A full list of features can be found here:
    // http://msdn.microsoft.com/library/default.asp?url=/library/en-us/shellcc/platform/commctls/richedit/richeditcontrols/aboutricheditcontrols.asp
     
    // There are a couple of caveats:
    // 
    // 1. The control that this is bound to was shipped with Windows XP, and so this code won't work in 
    //    Windows 2000 or earlier. 
    //
    // 2. The RichTextBox control in C# only knows about version 2, so the interface doesn't include 
    //    all the new features. You can wrap a few of the features yourself through new methods on the 
    //    RichEdit class.
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    internal class RichEdit : RichTextBox
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr LoadLibrary(string lpFileName);
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parameters = base.CreateParams;
                if (LoadLibrary("msftedit.dll") != IntPtr.Zero)
                {
                    parameters.ExStyle |= 0x020; // transparent
                    parameters.ClassName = "RICHEDIT50W";
                }
                return parameters;
            }
        }
    }
