    using Microsoft.Office.Interop.Excel;
    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace TestVBACompilation
    {
        internal class TestVBACompilationMain
        {
            private static void Main(string[] args)
            {
                Console.WriteLine(TestMainFile("Excel 2016 32-bit", @"C:\Program Files (x86)\Microsoft Office\root\Office16\EXCEL.EXE", @"C:\Users\LocalAdmin\Downloads\XXX.xlsm"));
                Console.WriteLine(TestMainFile("Excel 2016 32-bit", @"C:\Program Files (x86)\Microsoft Office\root\Office16\EXCEL.EXE", @"C:\Users\LocalAdmin\Downloads\YYY.xlsm"));
                Console.ReadLine();
            }
    
            /// <summary>
            /// Call this method with each version of the file and the version of excel you wish to test with
            /// </summary>
            /// <param name="pathToFileToTest"></param>
            /// <param name="pathToTheVersionOfExcel"></param>
            /// <param name="excelVersionFriendlyText"></param>
            /// <returns></returns>
            private static string TestMainFile(string excelVersionFriendlyText,
                string pathToTheVersionOfExcel,
                string pathToFileToTest
                )
            {
                TestVBACompilationMain program = new TestVBACompilationMain();
                string returnText = "";
    
                program.UpdateRegistryKey();
                program.KillAllExcelFileProcesses();
    
                //A compromise: https://stackoverflow.com/questions/25319484/how-do-i-get-a-return-value-from-task-waitall-in-a-console-app
                string compileFileResults = "";
                using (Task results = new Task(() => compileFileResults = program.CompileExcelFile(excelVersionFriendlyText, pathToTheVersionOfExcel, pathToFileToTest)))
                {
                    results.Start();
                    results.Wait(30000); //May need to be adjusted depending on conditions
    
                    returnText = "Test: " + (results.IsCompleted ? compileFileResults : "FAILED: File not compiled due to timeout error");
    
                    program.KillAllExcelFileProcesses();
                    results.Wait();
                }
    
                return returnText;
            }
    
            /// <summary>
            /// This should be run in a task with a timeout, can be dangerous as if excel prompts for something this will run forever...
            /// </summary>
            /// <param name="pathToTheVersionOfExcel"></param>
            /// <param name="pathToFileToTest"></param>
            /// <param name="amountOfTimeToWaitForFailure">I've played around with it, depends on what plugins you have installed, for me 10 seconds seems to work good</param>
            /// <returns></returns>
            private string CompileExcelFile(string excelVersionFriendlyText,
                string pathToTheVersionOfExcel,
                string pathToFileToTest,
                int amountOfTimeToWaitForFailure = 10000)
            {
                string returnValue = "";
                Application oExcelApp = null;
                Workbook mainWorkbook = null;
    
                try
                {
                    //TODO: I still need to figure out how to run specific versions of excel using the "pathToTheVersionOfExcel" variable, right now it just runs the default one installed
                    //In the future I will add support to run multiple versions on one machine
                    oExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    mainWorkbook = oExcelApp.Workbooks.Open(pathToFileToTest);
    
                    Workbook activeWorkbook = oExcelApp.ActiveWorkbook;
                    Worksheet activeSheet = (Worksheet)activeWorkbook.ActiveSheet;
    
                    //Remember the following code needs to be present in your VBA file
                    //https://stackoverflow.com/a/55613985/2912011
                    dynamic results = oExcelApp.Run("Compiler");
                    Thread.Sleep(amountOfTimeToWaitForFailure);
    
                    //This could be improved, love to have the VBA method tell me what failed, that's still outstanding: https://stackoverflow.com/questions/55621735/vba-method-to-detect-compilation-failure
                    if (Process.GetProcessesByName("EXCEL")[0].MainWindowTitle.Contains("Microsoft Visual Basic for Applications"))
                    {
                        returnValue = "FAILED: \"Microsoft Visual Basic for Applications\" has popped up, this file failed to compile.";
                    }
                    else
                    {
                        returnValue = "PASSED: File Compiled Successfully: " + (string)results;
                    }
                }
                catch (Exception e)
                {
                    returnValue = "FAILED: Failed to start excel or run the compile method. " + e.Message;
                }
                finally
                {
                    try
                    {
                        if (mainWorkbook != null)
                        {
                            //This will typically fail if the compiler failed and is prompting the user for something
                            mainWorkbook.Close(false, null, null);
                        }
    
                        if (oExcelApp != null)
                        {
                            oExcelApp.Quit();
                        }
    
                        if (oExcelApp != null)
                        {
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcelApp);
                        }
                    }
                    catch (Exception innerException)
                    {
                        returnValue = "FAILED: Failed to close the excel file, typically indicative of a compilation error - " + innerException.Message;
                    }
                }
    
                return excelVersionFriendlyText + " - " + returnValue;
            }
    
            /// <summary>
            /// This is reponsible for verifying the correct excel options are enabled, see https://stackoverflow.com/a/5301556/2912011
            /// </summary>
            private void UpdateRegistryKey()
            {
                //Office 2010
                //https://stackoverflow.com/a/3267832/2912011  
                RegistryKey myKey2010 = Registry.LocalMachine.OpenSubKey(@"HKEY_CURRENT_USER\Software\Microsoft\Office\14.0\Excel\Security\AccessVBOM", true);
                if (myKey2010 != null)
                {
                    myKey2010.SetValue("AccessVBOM", 1, RegistryValueKind.DWord);
                    myKey2010.Close();
                }
    
                //Office 2013
                RegistryKey myKey2013 = Registry.LocalMachine.OpenSubKey(@"HKEY_CURRENT_USER\Software\Microsoft\Office\15.0\Excel\Security\AccessVBOM", true);
                if (myKey2013 != null)
                {
                    myKey2013.SetValue("AccessVBOM", 1, RegistryValueKind.DWord);
                    myKey2013.Close();
                }
    
                //Office 2016
                RegistryKey myKey2016 = Registry.LocalMachine.OpenSubKey(@"HKEY_CURRENT_USER\Software\Microsoft\Office\16.0\Excel\Security\AccessVBOM", true);
                if (myKey2016 != null)
                {
                    myKey2016.SetValue("AccessVBOM", 1, RegistryValueKind.DWord);
                    myKey2016.Close();
                }
            }
    
            /// <summary>
            /// Big hammer, just kill everything and start the specified version of excel
            /// </summary>
            private void KillAllExcelFileProcesses()
            {
                //TODO: We could tune this to just the application that we opened/want to use
                foreach (Process process in Process.GetProcessesByName("EXCEL"))
                {
                    process.Kill();
                }
            }
        }
    }
