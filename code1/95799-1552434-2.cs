    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication11
    {
      using SLID = Guid; //SLID id declarated as typedef GUID SLID; in slpublic.h 
    
      class Program
      {
    
        public enum SL_GENUINE_STATE
        {
          SL_GEN_STATE_IS_GENUINE       = 0,
          SL_GEN_STATE_INVALID_LICENSE  = 1,
          SL_GEN_STATE_TAMPERED         = 2,
          SL_GEN_STATE_OFFLINE          = 3,
          SL_GEN_STATE_LAST             = 4
        }
    
        [DllImportAttribute("Slwga.dll", EntryPoint = "SLIsGenuineLocal", CharSet = CharSet.None, ExactSpelling = false, SetLastError = false, PreserveSig = true, CallingConvention = CallingConvention.Winapi, BestFitMapping = false, ThrowOnUnmappableChar = false)]
        [PreserveSigAttribute()]
        internal static extern uint SLIsGenuineLocal(ref SLID slid, [In, Out] ref SL_GENUINE_STATE genuineState, IntPtr val3);
    
    
        public static bool IsGenuineWindows()
        {
            bool _IsGenuineWindows   = false;
            Guid ApplicationID       = new Guid("55c92734-d682-4d71-983e-d6ec3f16059f"); //Application ID GUID http://technet.microsoft.com/en-us/library/dd772270.aspx
            SLID windowsSlid = (Guid)ApplicationID;  
            try
            {
              SL_GENUINE_STATE genuineState = SL_GENUINE_STATE.SL_GEN_STATE_LAST;
              uint ResultInt                = SLIsGenuineLocal(ref windowsSlid, ref genuineState, IntPtr.Zero);
              if (ResultInt == 0)
              {
                _IsGenuineWindows = (genuineState == SL_GENUINE_STATE.SL_GEN_STATE_IS_GENUINE);
              }
              else
              {
                Console.WriteLine("Error getting information {0}", ResultInt.ToString());          
              }
    
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
            }
            return _IsGenuineWindows;
        }    
        
        static void Main(string[] args)
        {
          if (Environment.OSVersion.Version.Major >= 6) //Version 6 can be Windows Vista, Windows Server 2008, or Windows 7
          {
            if (IsGenuineWindows())
            {
              Console.WriteLine("Original Windows");        
            }
            else
            {
              Console.WriteLine("Not Original Windows");                
            }
          }
          else
          {
            Console.WriteLine("OS Not supoprted");     
          }
          Console.ReadLine();
        }
      }
    }
