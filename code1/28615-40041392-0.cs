        using System;
        using System.Collections.Generic;
        using System.Diagnostics;
        using System.IO;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        
        namespace BigFileService
        {    
            public class BigFileDumper
            {
                /// <summary>
                /// Buffer that will store the lines until it is full.
                /// Then it will dump it to temp files.
                /// </summary>
                public int CHUNK_SIZE = 1000;
                public bool ReverseIt { get; set; }
                public long TotalLineCount { get { return totalLineCount; } }
                private long totalLineCount;
                private int BufferCount = 0;
                private StreamWriter Writer;
                /// <summary>
                /// List of files that would store the chunks.
                /// </summary>
                private List<string> LstTempFiles;
                private string ParentDirectory;
                private char[] trimchars = { '/', '\\'};
        
        
                public BigFileDumper(string FolderPathToWrite)
                {
                    this.LstTempFiles = new List<string>();
                    this.ParentDirectory = FolderPathToWrite.TrimEnd(trimchars) + "\\" + "BIG_FILE_DUMP";
                    this.totalLineCount = 0;
                    this.BufferCount = 0;
                    this.Initialize();
                }
        
                private void Initialize()
                {
                    // Delete existing directory.
                    if (Directory.Exists(this.ParentDirectory))
                    {
                        Directory.Delete(this.ParentDirectory, true);
                    }
        
                    // Create a new directory.
                    Directory.CreateDirectory(this.ParentDirectory);
                }
        
                public void WriteLine(string line)
                {
                    if (this.BufferCount == 0)
                    {
                        string newFile = "DumpFile_" + LstTempFiles.Count();
                        LstTempFiles.Add(newFile);
                        Writer = new StreamWriter(this.ParentDirectory + "\\" + newFile);
                    }
                    // Keep on adding in the buffer as long as size is okay.
                    if (this.BufferCount < this.CHUNK_SIZE)
                    {
                        this.totalLineCount++; // main count
                        this.BufferCount++; // Chunk count.
                        Writer.WriteLine(line);
                    }
                    else
                    {
                        // Buffer is full, time to create a new file.
                        // Close the existing file first.
                        Writer.Close();
                        // Make buffer count 0 again.
                        this.BufferCount = 0;
                        this.WriteLine(line);
                    }
                }
        
                public void Close()
                {
                    if (Writer != null)
                        Writer.Close();
                }
        
                public string GetFullFile()
                {
                    if (LstTempFiles.Count <= 0)
                    {
                        Debug.Assert(false, "There are no files created.");
                        return "";
                    }
                    string returnFilename = this.ParentDirectory + "\\" + "FullFile";
                    if (File.Exists(returnFilename) == false)
                    {
                        // Create a consolidated file from the existing small dump files.
                        // Now this is interesting. We will open the small dump files one by one.
                        // Depending on whether the user require inverted file, we will read them in descending order & reverted, 
                        // or ascending order in normal way.
        
                        if (this.ReverseIt)
                            this.LstTempFiles.Reverse();
        
                        foreach (var fileName in LstTempFiles)
                        {
                            string fullFileName = this.ParentDirectory + "\\" + fileName;
                            var fileLines = File.ReadAllLines(fullFileName);
        
                            // Time to right in the writer.
                            if (this.ReverseIt)
                                fileLines = fileLines.Reverse().ToArray();
        
                            // Write the lines 
                            File.AppendAllLines(returnFilename, fileLines);
                        }
                    }
        
                    return returnFilename;
                }
            }
        }
    
