    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    #pragma warning disable 1591
    // ReSharper disable InconsistentNaming
    
    namespace <put_your_appropriate_namespace_here>
    {
       public class shell
       {
          [DllImport("shlwapi.dll")]
          public extern static int AssocCreate(
             Guid clsid,
             ref Guid riid,
             [MarshalAs(UnmanagedType.Interface)] out object ppv);
    
          [Flags]
          public enum ASSOCF
          {
             INIT_NOREMAPCLSID = 0x00000001,
             INIT_BYEXENAME = 0x00000002,
             OPEN_BYEXENAME = 0x00000002,
             INIT_DEFAULTTOSTAR = 0x00000004,
             INIT_DEFAULTTOFOLDER = 0x00000008,
             NOUSERSETTINGS = 0x00000010,
             NOTRUNCATE = 0x00000020,
             VERIFY = 0x00000040,
             REMAPRUNDLL = 0x00000080,
             NOFIXUPS = 0x00000100,
             IGNOREBASECLASS = 0x00000200,
             INIT_IGNOREUNKNOWN = 0x00000400
          }
    
          public enum ASSOCSTR
          {
             COMMAND = 1,
             EXECUTABLE,
             FRIENDLYDOCNAME,
             FRIENDLYAPPNAME,
             NOOPEN,
             SHELLNEWVALUE,
             DDECOMMAND,
             DDEIFEXEC,
             DDEAPPLICATION,
             DDETOPIC,
             INFOTIP,
             QUICKTIP,
             TILEINFO,
             CONTENTTYPE,
             DEFAULTICON,
             SHELLEXTENSION
          }
    
          public enum ASSOCKEY
          {
             SHELLEXECCLASS = 1,
             APP,
             CLASS,
             BASECLASS
          }
    
          public enum ASSOCDATA
          {
             MSIDESCRIPTOR = 1,
             NOACTIVATEHANDLER,
             QUERYCLASSSTORE,
             HASPERUSERASSOC,
             EDITFLAGS,
             VALUE
          }
    
          [Guid("c46ca590-3c3f-11d2-bee6-0000f805ca57"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
          public interface IQueryAssociations
          {
             void Init(
               [In] ASSOCF flags,
               [In, MarshalAs(UnmanagedType.LPWStr)] string pszAssoc,
               [In] UIntPtr hkProgid,
               [In] IntPtr hwnd);
    
             void GetString(
               [In] ASSOCF flags,
               [In] ASSOCSTR str,
               [In, MarshalAs(UnmanagedType.LPWStr)] string pwszExtra,
               [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszOut,
               [In, Out] ref int pcchOut);
    
             void GetKey(
               [In] ASSOCF flags,
               [In] ASSOCKEY str,
               [In, MarshalAs(UnmanagedType.LPWStr)] string pwszExtra,
               [Out] out UIntPtr phkeyOut);
    
             void GetData(
               [In] ASSOCF flags,
               [In] ASSOCDATA data,
               [In, MarshalAs(UnmanagedType.LPWStr)] string pwszExtra,
               [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] out byte[] pvOut,
               [In, Out] ref int pcbOut);
    
             void GetEnum(); // not used actually
          }
    
          public static Guid CLSID_QueryAssociations = new Guid("a07034fd-6caa-4954-ac3f-97a27216f98a");
          public static Guid IID_IQueryAssociations = new Guid("c46ca590-3c3f-11d2-bee6-0000f805ca57");
    
       }
    }
    
