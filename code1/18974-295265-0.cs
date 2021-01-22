    using System;
    using System.Runtime.InteropServices;
    using LogQuery = Interop.MSUtil.LogQueryClass;
    using RegistryInputFormat = Interop.MSUtil.COMRegistryInputContextClass;
    using RegRecordSet = Interop.MSUtil.ILogRecordset;
    
    class Program
    {
    public static void Main()
    {
    RegRecordSet rs = null;
    try
    {
    LogQuery qry = new LogQuery();
    RegistryInputFormat registryFormat = new RegistryInputFormat();
    string query = @"SELECT Path from \HKLM\SOFTWARE\Microsoft where
    Value='VisualStudio'";
    rs = qry.Execute(query, registryFormat);
    for(; !rs.atEnd(); rs.moveNext())
    Console.WriteLine(rs.getRecord().toNativeString(","));
    }
    finally
    {
    rs.close();
    }
    }
    }
