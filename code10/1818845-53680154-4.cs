    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    
    using Microsoft.Office.Interop.Word;
    
    namespace ConsoleApp
    {
        internal class Program
        {
            #region public methods
    
            private static void Main(string[] args)
            {
                Application word1 = new Application();
                word1.Visible = false;
                word1.Documents.Add();
    
                Application word2 = new Application();
                word2.Visible = true;
                word2.Documents.Add();
                word2.Documents.Add();
    
                Application word3 = new Application();
                word3.Visible = false;
                word3.Documents.Add();
                word3.Documents.Add();
                word3.Documents.Add();
    
                List<(IMoniker moniker, IBindCtx bindingContext, object instance)> x = Program.GetRunningComObjects();
                foreach ( (IMoniker moniker, IBindCtx bindingContext, object instance)  in x)
                {
                    // get only the instances that 
                    if (instance is Document doc && doc.Application.ActiveDocument == doc)
                    {
                        moniker.GetDisplayName(bindingContext, moniker, out string displayName);
                        Console.WriteLine($"{displayName}");
    
                        Application wordInstance = doc.Application;
                        Console.WriteLine($"\tVisible:\t{wordInstance.Visible}");
                        Console.WriteLine($"\tDocumentCount:\t{wordInstance.Documents.Count}");
                    }
                }
    
                word1.Quit(false);
                word2.Quit(false);
                word3.Quit(false);
    
                Console.WriteLine();
                Console.WriteLine("##############      End of program     ##############");
                Console.WriteLine("############## press enter to continue ##############");
                Console.ReadLine();
            }
    
            [DllImport("ole32.dll")]
            private static extern int CreateBindCtx(int reserved, out IBindCtx ppbc);
    
            [DllImport("ole32.dll")]
            private static extern int GetRunningObjectTable(uint reserved, out IRunningObjectTable pprot);
    
            private static List<(IMoniker moniker, IBindCtx bindingContext, object instance)> GetRunningComObjects()
            {
                List<(IMoniker, IBindCtx, object)> result = new List<(IMoniker, IBindCtx, object)>();
                IRunningObjectTable runningObjectTable = null;
                IEnumMoniker monikerList = null;
    
                try
                {
                    if (Program.GetRunningObjectTable(0, out runningObjectTable) != 0
                        || runningObjectTable == null)
                    {
                        return result;
                    }
    
                    runningObjectTable.EnumRunning(out monikerList);
                    monikerList.Reset();
                    IMoniker[] monikerContainer = new IMoniker[1];
                    IntPtr pointerFetchedMonikers = IntPtr.Zero;
                    while (monikerList.Next(1, monikerContainer, pointerFetchedMonikers) == 0)
                    {
                        Program.CreateBindCtx(0, out IBindCtx bindingContext);
                        runningObjectTable.GetObject(monikerContainer[0], out object comInstance);
                        result.Add((monikerContainer[0], bindingContext, comInstance));
                    }
                }
                finally
                {
                    if (runningObjectTable != null)
                    {
                        Marshal.ReleaseComObject(runningObjectTable);
                    }
    
                    if (monikerList != null)
                    {
                        Marshal.ReleaseComObject(monikerList);
                    }
                }
    
                return result;
            }
    
            #endregion
        }
    }
