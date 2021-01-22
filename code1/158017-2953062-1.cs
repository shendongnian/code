        public void WhichVersion(string mdbPath)
        {
            Microsoft.Office.Interop.Access.Application oAccess = new Microsoft.Office.Interop.Access.ApplicationClass();
            oAccess.OpenCurrentDatabase(mdbPath, false, "");
            Microsoft.Office.Interop.Access.AcFileFormat fileFormat = oAccess.CurrentProject.FileFormat;
            switch (fileFormat)
            {
                case Microsoft.Office.Interop.Access.AcFileFormat.acFileFormatAccess2:
                    Console.WriteLine("Microsoft Access 2"); break;
                case Microsoft.Office.Interop.Access.AcFileFormat.acFileFormatAccess95:
                    Console.WriteLine("Microsoft Access 95"); break;
                case Microsoft.Office.Interop.Access.AcFileFormat.acFileFormatAccess97:
                    Console.WriteLine("Microsoft Access 97"); break;
                case Microsoft.Office.Interop.Access.AcFileFormat.acFileFormatAccess2000:
                    Console.WriteLine("Microsoft Access 2000"); break;
                case Microsoft.Office.Interop.Access.AcFileFormat.acFileFormatAccess2002:
                    Console.WriteLine("Microsoft Access 2003"); break;
            }
            oAccess.Quit(Microsoft.Office.Interop.Access.AcQuitOption.acQuitSaveNone);
            Marshal.ReleaseComObject(oAccess);
            oAccess = null;
        }
    }
