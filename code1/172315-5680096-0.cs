    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Diagnostics;
    using System.Management;
    namespace KillProcessTree
    {
    public static class MyExtensions
    {
        public static int GetParentProcessId(this Process p)
        {
            int parentId = 0;
            try
            {
                ManagementObject mo = new ManagementObject("win32_process.handle='" + p.Id + "'");
                mo.Get();
                parentId = Convert.ToInt32(mo["ParentProcessId"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                parentId = 0;
            }
            return parentId;
        }
    }
