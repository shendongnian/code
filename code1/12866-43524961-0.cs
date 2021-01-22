    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Reflection;
    using System.Threading;
    using System.Xml;
    public struct CException
    {
      //----------------------------------------------------------------------------
      public CException(Exception i_oException)
      {
        m_oException = i_oException;
        m_oCultureInfo = null;
        m_sMessage = null;
      }
      //----------------------------------------------------------------------------
      public CException(Exception i_oException, string i_sCulture)
      {
        m_oException = i_oException;
        try
        { m_oCultureInfo = new CultureInfo(i_sCulture); }
        catch
        { m_oCultureInfo = CultureInfo.InvariantCulture; }
        m_sMessage = null;
      }
      //----------------------------------------------------------------------------
      public CException(Exception i_oException, CultureInfo i_oCultureInfo)
      {
        m_oException = i_oException;
        m_oCultureInfo = i_oCultureInfo == null ? CultureInfo.InvariantCulture : i_oCultureInfo;
        m_sMessage = null;
      }
      //----------------------------------------------------------------------------
      // GetMessage
      //----------------------------------------------------------------------------
      public string GetMessage() { return GetMessage(m_oException, m_oCultureInfo); }
      public string GetMessage(String i_sCulture) { return GetMessage(m_oException, i_sCulture); }
      public string GetMessage(CultureInfo i_oCultureInfo) { return GetMessage(m_oException, i_oCultureInfo); }
      public static string GetMessage(Exception i_oException) { return GetMessage(i_oException, CultureInfo.InvariantCulture); }
      public static string GetMessage(Exception i_oException, string i_sCulture)
      {
        CultureInfo oCultureInfo = null;
        try
        { oCultureInfo = new CultureInfo(i_sCulture); }
        catch
        { oCultureInfo = CultureInfo.InvariantCulture; }
        return GetMessage(i_oException, oCultureInfo);
      }
      public static string GetMessage(Exception i_oException, CultureInfo i_oCultureInfo)
      {
        if (i_oException == null) return null;
        if (i_oCultureInfo == null) i_oCultureInfo = CultureInfo.InvariantCulture;
        if (ms_dictCultureExceptionMessages == null) return null;
        if (!ms_dictCultureExceptionMessages.ContainsKey(i_oCultureInfo))
          return CreateMessage(i_oException, i_oCultureInfo);
        Dictionary<string, string> dictExceptionMessage = ms_dictCultureExceptionMessages[i_oCultureInfo];
        string sExceptionName = i_oException.GetType().FullName;
        sExceptionName = MakeXMLCompliant(sExceptionName);
        Win32Exception oWin32Exception = (Win32Exception)i_oException;
        if (oWin32Exception != null)
          sExceptionName += "_" + oWin32Exception.NativeErrorCode;
        if (dictExceptionMessage.ContainsKey(sExceptionName))
          return dictExceptionMessage[sExceptionName];
        else
          return CreateMessage(i_oException, i_oCultureInfo);
      }
      //----------------------------------------------------------------------------
      // CreateMessages
      //----------------------------------------------------------------------------
      public static void CreateMessages(CultureInfo i_oCultureInfo)
      {
        Thread oTH = new Thread(new ThreadStart(CreateMessagesInThread));
        if (i_oCultureInfo != null)
        {
          oTH.CurrentCulture = i_oCultureInfo;
          oTH.CurrentUICulture = i_oCultureInfo;
        }
        oTH.Start();
        while (oTH.IsAlive)
        { Thread.Sleep(10); }
      }
      //----------------------------------------------------------------------------
      // LoadMessagesFromXML
      //----------------------------------------------------------------------------
      public static void LoadMessagesFromXML(string i_sPath, string i_sBaseFilename)
      {
        if (i_sBaseFilename == null) i_sBaseFilename = msc_sBaseFilename;
        string[] asFiles = null;
        try
        {
          asFiles = System.IO.Directory.GetFiles(i_sPath, i_sBaseFilename + "_*.xml");
        }
        catch { return; }
        ms_dictCultureExceptionMessages.Clear();
        for (int ixFile = 0; ixFile < asFiles.Length; ixFile++)
        {
          string sXmlPathFilename = asFiles[ixFile];
          XmlDocument xmldoc = new XmlDocument();
          try
          {
            xmldoc.Load(sXmlPathFilename);
            XmlNode xmlnodeRoot = xmldoc.SelectSingleNode("/" + msc_sXmlGroup_Root);
            string sCulture = xmlnodeRoot.SelectSingleNode(msc_sXmlGroup_Info + "/" + msc_sXmlData_Culture).Value;
            CultureInfo oCultureInfo = new CultureInfo(sCulture);
            XmlNode xmlnodeMessages = xmlnodeRoot.SelectSingleNode(msc_sXmlGroup_Messages);
            XmlNodeList xmlnodelistMessage = xmlnodeMessages.ChildNodes;
            Dictionary<string, string> dictExceptionMessage = new Dictionary<string, string>(xmlnodelistMessage.Count + 10);
            for (int ixNode = 0; ixNode < xmlnodelistMessage.Count; ixNode++)
              dictExceptionMessage.Add(xmlnodelistMessage[ixNode].Name, xmlnodelistMessage[ixNode].Value);
            ms_dictCultureExceptionMessages.Add(oCultureInfo, dictExceptionMessage);
          }
          catch
          { return; }
        }
      }
      //----------------------------------------------------------------------------
      // SaveMessagesToXML
      //----------------------------------------------------------------------------
      public static void SaveMessagesToXML(string i_sPath, string i_sBaseFilename)
      {
        if (i_sBaseFilename == null) i_sBaseFilename = msc_sBaseFilename;
        foreach (KeyValuePair<CultureInfo, Dictionary<string, string>> kvpCultureExceptionMessages in ms_dictCultureExceptionMessages)
        {
          string sXmlPathFilename = i_sPath + i_sBaseFilename + "_" + kvpCultureExceptionMessages.Key.TwoLetterISOLanguageName + ".xml";
          Dictionary<string, string> dictExceptionMessage = kvpCultureExceptionMessages.Value;
          XmlDocument xmldoc = new XmlDocument();
          XmlWriter xmlwriter = null;
          XmlWriterSettings writerSettings = new XmlWriterSettings();
          writerSettings.Indent = true;
          try
          {
            XmlNode xmlnodeRoot = xmldoc.CreateElement(msc_sXmlGroup_Root);
            xmldoc.AppendChild(xmlnodeRoot);
            XmlNode xmlnodeInfo = xmldoc.CreateElement(msc_sXmlGroup_Info);
            XmlNode xmlnodeMessages = xmldoc.CreateElement(msc_sXmlGroup_Messages);
            xmlnodeRoot.AppendChild(xmlnodeInfo);
            xmlnodeRoot.AppendChild(xmlnodeMessages);
            XmlNode xmlnodeCulture = xmldoc.CreateElement(msc_sXmlData_Culture);
            xmlnodeCulture.InnerText = kvpCultureExceptionMessages.Key.Name;
            xmlnodeInfo.AppendChild(xmlnodeCulture);
            foreach (KeyValuePair<string, string> kvpExceptionMessage in dictExceptionMessage)
            {
              XmlNode xmlnodeMsg = xmldoc.CreateElement(kvpExceptionMessage.Key);
              xmlnodeMsg.InnerText = kvpExceptionMessage.Value;
              xmlnodeMessages.AppendChild(xmlnodeMsg);
            }
            xmlwriter = XmlWriter.Create(sXmlPathFilename, writerSettings);
            xmldoc.WriteTo(xmlwriter);
          }
          catch (Exception e)
          { return; }
          finally
          { if (xmlwriter != null) xmlwriter.Close(); }
        }
      }
      //----------------------------------------------------------------------------
      // CreateMessagesInThread
      //----------------------------------------------------------------------------
      private static void CreateMessagesInThread()
      {
        Thread.CurrentThread.Name = "CException.CreateMessagesInThread";
        Dictionary<string, string> dictExceptionMessage = new Dictionary<string, string>(0x1000);
        GetExceptionMessages(dictExceptionMessage);
        GetExceptionMessagesWin32(dictExceptionMessage);
        ms_dictCultureExceptionMessages.Add(Thread.CurrentThread.CurrentUICulture, dictExceptionMessage);
      }
      //----------------------------------------------------------------------------
      // GetExceptionTypes
      //----------------------------------------------------------------------------
      private static List<Type> GetExceptionTypes()
      {
        Assembly[] aoAssembly = AppDomain.CurrentDomain.GetAssemblies();
        List<Type> listoExceptionType = new List<Type>();
        Type oExceptionType = typeof(Exception);
        for (int ixAssm = 0; ixAssm < aoAssembly.Length; ixAssm++)
        {
          if (!aoAssembly[ixAssm].GlobalAssemblyCache) continue;
          Type[] aoType = aoAssembly[ixAssm].GetTypes();
          for (int ixType = 0; ixType < aoType.Length; ixType++)
          {
            if (aoType[ixType].IsSubclassOf(oExceptionType))
              listoExceptionType.Add(aoType[ixType]);
          }
        }
        return listoExceptionType;
      }
      //----------------------------------------------------------------------------
      // GetExceptionMessages
      //----------------------------------------------------------------------------
      private static void GetExceptionMessages(Dictionary<string, string> i_dictExceptionMessage)
      {
        List<Type> listoExceptionType = GetExceptionTypes();
        for (int ixException = 0; ixException < listoExceptionType.Count; ixException++)
        {
          Type oExceptionType = listoExceptionType[ixException];
          string sExceptionName = MakeXMLCompliant(oExceptionType.FullName);
          try
          {
            if (i_dictExceptionMessage.ContainsKey(sExceptionName))
              continue;
            Exception e = (Exception)(Activator.CreateInstance(oExceptionType));
            i_dictExceptionMessage.Add(sExceptionName, e.Message);
          }
          catch (Exception)
          { i_dictExceptionMessage.Add(sExceptionName, null); }
        }
      }
      //----------------------------------------------------------------------------
      // GetExceptionMessagesWin32
      //----------------------------------------------------------------------------
      private static void GetExceptionMessagesWin32(Dictionary<string, string> i_dictExceptionMessage)
      {
        string sTypeName = MakeXMLCompliant(typeof(Win32Exception).FullName) + "_";
        for (int iError = 0; iError < 0x4000; iError++)  // Win32 errors may range from 0 to 0xFFFF
        {
          Exception e = new Win32Exception(iError);
          if (!e.Message.StartsWith("Unknown error (", StringComparison.OrdinalIgnoreCase))
            i_dictExceptionMessage.Add(sTypeName + iError, e.Message);
        }
      }
      //----------------------------------------------------------------------------
      // CreateMessage
      //----------------------------------------------------------------------------
      private static string CreateMessage(Exception i_oException, CultureInfo i_oCultureInfo)
      {
        CException oEx = new CException(i_oException, i_oCultureInfo);
        Thread oTH = new Thread(new ParameterizedThreadStart(CreateMessageInThread));
        oTH.Start(oEx);
        while (oTH.IsAlive)
        { Thread.Sleep(10); }
        return oEx.m_sMessage;
      }
      //----------------------------------------------------------------------------
      // CreateMessageInThread
      //----------------------------------------------------------------------------
      private static void CreateMessageInThread(Object i_oData)
      {
        if (i_oData == null) return;
        CException oEx = (CException)i_oData;
        if (oEx.m_oException == null) return;
        Thread.CurrentThread.CurrentUICulture = oEx.m_oCultureInfo == null ? CultureInfo.InvariantCulture : oEx.m_oCultureInfo;
        // create new exception in desired culture
        Exception e = null;
        Win32Exception oWin32Exception = (Win32Exception)(oEx.m_oException);
        if (oWin32Exception != null)
          e = new Win32Exception(oWin32Exception.NativeErrorCode);
        else
        {
          try
          {
            e = (Exception)(Activator.CreateInstance(oEx.m_oException.GetType()));
          }
          catch { }
        }
        if (e != null)
          oEx.m_sMessage = e.Message;
      }
      //----------------------------------------------------------------------------
      // MakeXMLCompliant
      // from https://www.w3.org/TR/xml/
      //----------------------------------------------------------------------------
      private static string MakeXMLCompliant(string i_sName)
      {
        if (string.IsNullOrEmpty(i_sName))
          return "_";
        System.Text.StringBuilder oSB = new System.Text.StringBuilder();
        for (int ixChar = 0; ixChar < (i_sName == null ? 0 : i_sName.Length); ixChar++)
        {
          char character = i_sName[ixChar];
          if (IsXmlNodeNameCharacterValid(ixChar, character))
            oSB.Append(character);
        }
        if (oSB.Length <= 0)
          oSB.Append("_");
        return oSB.ToString();
      }
      //----------------------------------------------------------------------------
      private static bool IsXmlNodeNameCharacterValid(int i_ixPos, char i_character)
      {
        if (i_character == ':') return true;
        if (i_character == '_') return true;
        if (i_character >= 'A' && i_character <= 'Z') return true;
        if (i_character >= 'a' && i_character <= 'z') return true;
        if (i_character >= 0x00C0 && i_character <= 0x00D6) return true;
        if (i_character >= 0x00D8 && i_character <= 0x00F6) return true;
        if (i_character >= 0x00F8 && i_character <= 0x02FF) return true;
        if (i_character >= 0x0370 && i_character <= 0x037D) return true;
        if (i_character >= 0x037F && i_character <= 0x1FFF) return true;
        if (i_character >= 0x200C && i_character <= 0x200D) return true;
        if (i_character >= 0x2070 && i_character <= 0x218F) return true;
        if (i_character >= 0x2C00 && i_character <= 0x2FEF) return true;
        if (i_character >= 0x3001 && i_character <= 0xD7FF) return true;
        if (i_character >= 0xF900 && i_character <= 0xFDCF) return true;
        if (i_character >= 0xFDF0 && i_character <= 0xFFFD) return true;
        // if (i_character >= 0x10000 && i_character <= 0xEFFFF) return true;
        if (i_ixPos > 0)
        {
          if (i_character == '-') return true;
          if (i_character == '.') return true;
          if (i_character >= '0' && i_character <= '9') return true;
          if (i_character == 0xB7) return true;
          if (i_character >= 0x0300 && i_character <= 0x036F) return true;
          if (i_character >= 0x203F && i_character <= 0x2040) return true;
        }
        return false;
      }
      private static string msc_sBaseFilename = "exception_messages";
      private static string msc_sXmlGroup_Root = "exception_messages";
      private static string msc_sXmlGroup_Info = "info";
      private static string msc_sXmlGroup_Messages = "messages";
      private static string msc_sXmlData_Culture = "culture";
      private Exception m_oException;
      private CultureInfo m_oCultureInfo;
      private string m_sMessage;
      static Dictionary<CultureInfo, Dictionary<string, string>> ms_dictCultureExceptionMessages = new Dictionary<CultureInfo, Dictionary<string, string>>();
    }
    internal class Program
    {
      public static void Main()
      {
        CException.CreateMessages(null);
        CException.SaveMessagesToXML(@"d:\temp\", "emsg");
        CException.LoadMessagesFromXML(@"d:\temp\", "emsg");
      }
    }
