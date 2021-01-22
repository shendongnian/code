    using System;
    
    using Microsoft.VisualStudio.Coverage.Analysis;
    using System.Collections.Generic;
    
    /* References
    \ThirdPartyReferences\Microsoft Visual Studio 11.0\Microsoft.VisualStudio.Coverage.Analysis.dll
    \ThirdPartyReferences\Microsoft Visual Studio 11.0\Microsoft.VisualStudio.Coverage.Interop.dll
    */
    
    namespace MyCompany.VisualStudioExtensions.CodeCoverage.CoverageCoverterConsoleApp
    {
        class Program
        {
            static int Main(string[] args)
            {
                if (args.Length < 2)
                {
                    Console.WriteLine("Coverage Convert - reads VStest binary code coverage data, and outputs it in XML format.");
                    Console.WriteLine("Usage:  ConverageConvert <destinationfile> <sourcefile1> <sourcefile2> ... <sourcefileN>");
                    return 1;
                }
    
                string destinationFile = args[0];
                //destinationFile = @"C:\TestResults\MySuperMergedCoverage.coverage.converted.to.xml";
    
                List<string> sourceFiles = new List<string>();
    
                //files.Add(@"C:\MyCoverage1.coverage");
                //files.Add(@"C:\MyCoverage2.coverage");
                //files.Add(@"C:\MyCoverage3.coverage");
    
    
                /* get all the file names EXCEPT the first one */
                for (int i = 1; i < args.Length; i++)
                {
                    sourceFiles.Add(args[i]);
                }
    
                CoverageInfo mergedCoverage;
                try
                {
                    mergedCoverage = JoinCoverageFiles(sourceFiles);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error opening coverage data: {0}", e.Message);
                    return 1;
                }
    
                CoverageDS data = mergedCoverage.BuildDataSet();
    
                try
                {
                    data.WriteXml(destinationFile);
                }
                catch (Exception e)
                {
    
                    Console.WriteLine("Error writing to output file: {0}", e.Message);
                    return 1;
                }
    
                return 0;
            }
    
            private static CoverageInfo JoinCoverageFiles(IEnumerable<string> files)
            {
                if (files == null)
                    throw new ArgumentNullException("files");
    
                // This will represent the joined coverage files
                CoverageInfo returnItem = null;
                string path;
    
                try
                {
                    foreach (string sourceFile in files)
                    {
                        // Create from the current file
    
                        path = System.IO.Path.GetDirectoryName(sourceFile);
                        CoverageInfo current = CoverageInfo.CreateFromFile(sourceFile, new string[] { path }, new string[] { path });
    
                        if (returnItem == null)
                        {
                            // First time through, assign to result
                            returnItem = current;
                            continue;
                        }
    
                        // Not the first time through, join the result with the current
                        CoverageInfo joined = null;
                        try
                        {
                            joined = CoverageInfo.Join(returnItem, current);
                        }
                        finally
                        {
                            // Dispose current and result
                            current.Dispose();
                            current = null;
                            returnItem.Dispose();
                            returnItem = null;
                        }
    
                        returnItem = joined;
                    }
                }
                catch (Exception)
                {
                    if (returnItem != null)
                    {
                        returnItem.Dispose();
                    }
                    throw;
                }
    
                return returnItem;
            }
        }
    }
