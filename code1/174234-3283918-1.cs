    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace PrintSpoolerAPIExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var printers = System.Drawing.Printing.PrinterSettings.InstalledPrinters as IEnumerable;
    
                foreach (string printer in printers)
                {
                    var printerInfo = PrintSpoolerApi.GetPrinterProperty(printer);
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(string.Format("ServerName:{0}", printerInfo.ServerName));
                    sb.AppendLine(string.Format("PrinterName:{0}", printerInfo.PrinterName));
                    sb.AppendLine(string.Format("ShareName:{0}", printerInfo.ShareName));
                    sb.AppendLine(string.Format("PortName:{0}", printerInfo.PortName));
                    sb.AppendLine(string.Format("DriverName:{0}", printerInfo.DriverName));
                    sb.AppendLine(string.Format("Comment:{0}", printerInfo.Comment));
                    sb.AppendLine(string.Format("Location:{0}", printerInfo.Location));
                    sb.AppendLine(string.Format("DevMode:{0}", printerInfo.DevMode));
                    sb.AppendLine(string.Format("SepFile:{0}", printerInfo.SepFile));
                    sb.AppendLine(string.Format("PrintProcessor:{0}", printerInfo.PrintProcessor));
                    sb.AppendLine(string.Format("Datatype:{0}", printerInfo.Datatype));
                    sb.AppendLine(string.Format("Parameters:{0}", printerInfo.Parameters));
                    sb.AppendLine(string.Format("Attributes:{0}", printerInfo.Attributes));
                    sb.AppendLine(string.Format("Priority:{0}", printerInfo.Priority));
                    sb.AppendLine(string.Format("DefaultPriority:{0}", printerInfo.DefaultPriority));
                    sb.AppendLine(string.Format("StartTime:{0}", printerInfo.StartTime));
                    sb.AppendLine(string.Format("UntilTime:{0}", printerInfo.UntilTime));
                    sb.AppendLine(string.Format("Status:{0}", printerInfo.Status));
                    sb.AppendLine(string.Format("Jobs:{0}", printerInfo.Jobs));
                    sb.AppendLine(string.Format("AveragePpm:{0}", printerInfo.AveragePpm));
                    Console.WriteLine(sb.ToString());
                }
    
                Console.ReadLine();
            }
        }
    
        class PrintSpoolerApi
        {
            [DllImport("winspool.drv", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern bool OpenPrinter(
                [MarshalAs(UnmanagedType.LPTStr)]
                string printerName,
                out IntPtr printerHandle,
                PrinterDefaults printerDefaults);
    
            [DllImport("winspool.drv", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern bool GetPrinter(
                IntPtr printerHandle,
                int level,
                IntPtr printerData,
                int bufferSize,
                ref int printerDataSize);
    
            [DllImport("winspool.drv", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern bool ClosePrinter(
                IntPtr printerHandle);
    
            [StructLayout(LayoutKind.Sequential)]
            public struct PrinterDefaults
            {
                public IntPtr pDatatype;
                public IntPtr pDevMode;
                public int DesiredAccess;
            }
    
            public enum PrinterProperty
            {
                ServerName,
                PrinterName,
                ShareName,
                PortName,
                DriverName,
                Comment,
                Location,
                PrintProcessor,
                Datatype,
                Parameters,
                Attributes,
                Priority,
                DefaultPriority,
                StartTime,
                UntilTime,
                Status,
                Jobs,
                AveragePpm
            };
    
            public struct PrinterInfo2
            {
                [MarshalAs(UnmanagedType.LPTStr)]
                public string ServerName;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string PrinterName;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string ShareName;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string PortName;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string DriverName;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string Comment;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string Location;
                public IntPtr DevMode;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string SepFile;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string PrintProcessor;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string Datatype;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string Parameters;
                public IntPtr SecurityDescriptor;
                public uint Attributes;
                public uint Priority;
                public uint DefaultPriority;
                public uint StartTime;
                public uint UntilTime;
                public uint Status;
                public uint Jobs;
                public uint AveragePpm;
            }
    
            public static PrinterInfo2 GetPrinterProperty(string printerUncName)
            {
                var printerInfo2 = new PrinterInfo2();
    
                var pHandle = new IntPtr();
                var defaults = new PrinterDefaults();
                try
                {
                    //Open a handle to the printer
                    bool ok = OpenPrinter(printerUncName, out pHandle, defaults);
    
                    if (!ok)
                    {
                        //OpenPrinter failed, get the last known error and thrown it
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
    
                    //Here we determine the size of the data we to be returned
                    //Passing in 0 for the size will force the function to return the size of the data requested
                    int actualDataSize = 0;
                    GetPrinter(pHandle, 2, IntPtr.Zero, 0, ref actualDataSize);
    
                    int err = Marshal.GetLastWin32Error();
    
                    if (err == 122)
                    {
                        if (actualDataSize > 0)
                        {
                            //Allocate memory to the size of the data requested
                            IntPtr printerData = Marshal.AllocHGlobal(actualDataSize);
                            //Retrieve the actual information this time
                            GetPrinter(pHandle, 2, printerData, actualDataSize, ref actualDataSize);
    
                            //Marshal to our structure
                            printerInfo2 = (PrinterInfo2)Marshal.PtrToStructure(printerData, typeof(PrinterInfo2));
                            //We've made the conversion, now free up that memory
                            Marshal.FreeHGlobal(printerData);
                        }
                    }
                    else
                    {
                        throw new Win32Exception(err);
                    }
    
                    return printerInfo2;
                }
                finally
                {
                    //Always close the handle to the printer
                    ClosePrinter(pHandle);
                }
            }
        }
    }
