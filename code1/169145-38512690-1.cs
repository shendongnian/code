    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices.ComTypes;  
      
    class Program
    {
        static void Main(string[] args)
        {
            bool wbOpened = HelperClass.GetRunningObjects().FirstOrDefault(x => (System.IO.Path.GetFileName(x.Path) == "Some Workbook Name.xlsx") && (x.Obj is Microsoft.Office.Interop.Excel.Workbook)).Obj != null;
        }
    }
    class HelperClass
    {
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
