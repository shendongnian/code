            string assmSpec = "";  // OS PathName to assembly name...
            if (!File.Exists(assmSpec))
                throw new DataImportException(string.Format(
                    "Assembly [{0}] cannot be located.", assmSpec));
            // -------------------------------------------
            Assembly dA;
            try { dA = Assembly.LoadFrom(assmSpec); }
            catch(FileNotFoundException nfX)
            { throw new DataImportException(string.Format(
                "Assembly [{0}] cannot be located.", assmSpec), 
                nfX); }
            // -------------------------------------------
            // Now here you have to instantiate the class 
            // in the assembly by a string classname
            IImportData iImp = (IImportData)dA.CreateInstance
                              ([Some string value for class Name]);
            if (iImp == null)
                throw new DataImportException(
                    string.Format("Unable to instantiate {0} from {1}",
                        dataImporter.ClassName, dataImporter.AssemblyName));
            // -------------------------------------------
           iImp.Process();  // Here you call method on interface that the class implements
