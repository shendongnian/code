    Workbook wb = GetOpenedWB_ByPath("C:\MyWB.xlsx")
    if (wb.obj == null) //If null then Workbook is not already opened
    {
      ...
    }
---
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices.ComTypes;
    public class WBHelper
    {
        public static bool IsOpenedWB_ByName(string wbName)
        {
            return (GetOpenedWB_ByName(wbName) != null);
        }
        public static bool IsOpenedWB_ByPath(string wbPath)
        {
            return (GetOpenedWB_ByPath(wbPath)  != null);
        }
        public static Workbook GetOpenedWB_ByName(string wbName)
        {
            return (Workbook)GetRunningObjects().FirstOrDefault(x => (System.IO.Path.GetFileName(x.Path) == wbName) && (x.Obj is Workbook)).Obj;
        }
        public static Workbook GetOpenedWB_ByPath(string wbPath)
        {
            return (Workbook)GetRunningObjects().FirstOrDefault(x => (x.Path == wbPath) && (x.Obj is Workbook)).Obj;
        }
        public static List<RunningObject> GetRunningObjects()
        {
            // Get the table.
            List<RunningObject> roList = new List<RunningObject>();
            IBindCtx bc;
            CreateBindCtx(0, out bc);
            IRunningObjectTable runningObjectTable;
            bc.GetRunningObjectTable(out runningObjectTable);
            IEnumMoniker monikerEnumerator;
            runningObjectTable.EnumRunning(out monikerEnumerator);
            monikerEnumerator.Reset();
            // Enumerate and fill list
            IMoniker[] monikers = new IMoniker[1];
            IntPtr numFetched = IntPtr.Zero;
            List<object> names = new List<object>();
            List<object> books = new List<object>();
            while (monikerEnumerator.Next(1, monikers, numFetched) == 0)
            {
                RunningObject running;
                monikers[0].GetDisplayName(bc, null, out running.Path);
                runningObjectTable.GetObject(monikers[0], out running.Obj);
                roList.Add(running);
            }
            return roList;
        }
        public struct RunningObject
        {
            public string Path;
            public object Obj;
        }
        [System.Runtime.InteropServices.DllImport("ole32.dll")]
        static extern void CreateBindCtx(int a, out IBindCtx b);
    }
