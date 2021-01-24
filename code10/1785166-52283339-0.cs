     public void Test_Performance_WithFilledExcelFile()
        {
            // given
            var lorenzBahlsenCicToExcelJobWorker = new LorenzBahlsenCicToExcelJobWorker();
            var environment = new TestEnvironment(lorenzBahlsenCicToExcelJobWorker, nameof(Test_Performance_WithFilledExcelFile));
    
            string binDirectory = Path.GetDirectoryName(GetType().GetTypeInfo().Assembly.Location);
            var testFile = Path.Combine(binDirectory, "TestFiles", CICSynchronisedTestFile);
    
            var excelFileCurrent = Path.Combine(binDirectory, "TestFiles", "next_delivery.xlsx");
            var excelFolderTarget = environment.EnvironmentDataStoragePath;
            var destinationFile = Path.Combine(excelFolderTarget, "next_delivery.xlsx");
        
            File.Copy(excelFileCurrent, destinationFile);
         }
