    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    //After you've added this class code to your application, here's how you may want to use it:
    
    //Dim objclsINI As New clsINI("c:\fName.ini")
    //objclsINI.WriteINI("Settings", "ClockTime", "12:59")
    //objclsINI.WriteINI("Settings", "ClockTime", "12:59", "c:\test.ini")
    //Dim strData As String = objclsINI.ReadINI("Settings", "ClockTime", "(none)")
    
    public class clsINI
    {
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, System.Text.StringBuilder lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FlushPrivateProfileString(int lpApplicationName, int lpKeyName, int lpString, string lpFileName);
        // API functions
    
    
    
        string strFilename;
        string strSection;
    
        string strKey;
        // Constructor, accepting a filename
        public clsINI(string Filename)
        {
            strFilename = Filename;
        }
        // Overloaded Constructor Creating The Default FileName
        public clsINI()
        {
            strFilename = Application.StartupPath + "\\" + Application.ProductName + ".ini";
        }
    
        // filename property
        public string FileName {
            get { return strFilename; }
            set { strFilename = value; }
        }
        // Section property
        public string Section {
            get { return strSection; }
            set { strSection = value; }
        }
        // Key property
        public string Key {
            get { return strKey; }
            set { strKey = value; }
        }
    
        public string ReadINI(string Default)
        {
            string functionReturnValue = null;
            // Returns a string from your INI file
            int intCharCount = 0;
            string strMessage = null;
            System.Text.StringBuilder objResult = new System.Text.StringBuilder(256);
            strMessage = "";
            if (string.IsNullOrEmpty(strKey))
                strMessage = "The INI File Class Does Not Have A Defined Key To Read.";
            if (string.IsNullOrEmpty(strSection))
                strMessage = strMessage + ControlChars.CrLf + "The INI File Class Does Not Have A Defined Section To Read.";
            if (!string.IsNullOrEmpty(strMessage)) {
                MessageBox.Show(strMessage, "INI Error");
                return;
            }
            intCharCount = GetPrivateProfileString(strSection, strKey, Default, objResult, objResult.Capacity, strFilename);
            if (intCharCount > 0)
                functionReturnValue = Strings.Left(objResult.ToString(), intCharCount);
            return functionReturnValue;
        }
    
        public string ReadINI(string Key, string Default)
        {
            string functionReturnValue = null;
            // Returns a string from your INI file
            int intCharCount = 0;
            System.Text.StringBuilder objResult = new System.Text.StringBuilder(256);
            if (string.IsNullOrEmpty(strSection)) {
                MessageBox.Show("The INI File Class Does Not Have A Defined Section.", "INI Error");
                return;
            }
            strKey = Key;
            intCharCount = GetPrivateProfileString(strSection, Key, Default, objResult, objResult.Capacity, strFilename);
            if (intCharCount > 0)
                functionReturnValue = Strings.Left(objResult.ToString(), intCharCount);
            return functionReturnValue;
        }
    
        public string ReadINI(string Section, string Key, string Default)
        {
            string functionReturnValue = null;
            // Returns a string from your INI file
            int intCharCount = 0;
            System.Text.StringBuilder objResult = new System.Text.StringBuilder(256);
            strSection = Section;
            strKey = Key;
            intCharCount = GetPrivateProfileString(Section, Key, Default, objResult, objResult.Capacity, strFilename);
            if (intCharCount > 0)
                functionReturnValue = Strings.Left(objResult.ToString(), intCharCount);
            return functionReturnValue;
        }
    
        public string ReadINI(string Section, string Key, string Default, string sFileName)
        {
            string functionReturnValue = null;
            // Returns a string from your INI file
            int intCharCount = 0;
            System.Text.StringBuilder objResult = new System.Text.StringBuilder(256);
            strKey = Key;
            strSection = Section;
            strFilename = sFileName;
            intCharCount = GetPrivateProfileString(Section, Key, Default, objResult, objResult.Capacity, sFileName);
            if (intCharCount > 0)
                functionReturnValue = Strings.Left(objResult.ToString(), intCharCount);
            return functionReturnValue;
        }
    
        public void WriteINI(string Value)
        {
            // Writes a string to your INI file
            string strMessage = null;
            strMessage = "";
            if (string.IsNullOrEmpty(strKey))
                strMessage = "The INI File Class Does Not Have A Defined Key To Write.";
            if (string.IsNullOrEmpty(strSection))
                strMessage = strMessage + ControlChars.CrLf + "The INI File Class Does Not Have A Defined Section To Write.";
            if (!string.IsNullOrEmpty(strMessage)) {
                MessageBox.Show(strMessage, "INI Error");
                return;
            }
            WritePrivateProfileString(strSection, strKey, Value, strFilename);
            Flush();
        }
    
        public void WriteINI(string Key, string Value)
        {
            // Writes a string to your INI file
            if (string.IsNullOrEmpty(strSection)) {
                MessageBox.Show("The INI File Class Does Not Have A Defined Section To Write.", "INI Error");
                return;
            }
            WritePrivateProfileString(strSection, Key, Value, strFilename);
            Flush();
        }
    
        public void WriteINI(string Section, string Key, string Value)
        {
            // Writes a string to your INI file
            strKey = Key;
            strSection = Section;
            WritePrivateProfileString(Section, Key, Value, strFilename);
            Flush();
        }
    
        public void WriteINI(string Section, string Key, string Value, string sFileName)
        {
            strKey = Key;
            strSection = Section;
            strFilename = sFileName;
            // Writes a string to your INI file
            WritePrivateProfileString(Section, Key, Value, sFileName);
            Flush();
        }
    
        private void Flush()
        {
            // Stores all the cached changes to your INI file
            FlushPrivateProfileString(0, 0, 0, strFilename);
        }
    
    }
