    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using log4net.Appender;
    using log4net.Util;
    namespace PFX
    {
        public class CustomRollingFileAppender : RollingFileAppender
        {
            private String _baseFileExtension;
            private String _baseFileNameWithoutExtension;        
            private String _fileDeletePattern;
            private String _folder;        
            private String _backupSearchPattern;
            
            public CustomRollingFileAppender()
            {}
            public override void ActivateOptions()
            {
                base.ActivateOptions();
                         
                this._baseFileNameWithoutExtension = Path.GetFileNameWithoutExtension(this.File);
                this._baseFileExtension = Path.GetExtension(this.File);
                this._folder = Path.GetDirectoryName(this.File);            
                this._fileDeletePattern = $"{this._baseFileNameWithoutExtension}*{this._baseFileExtension}";
                this._backupSearchPattern = $"{this._baseFileNameWithoutExtension}.*{this._baseFileExtension}";            
            }               
            protected override void AdjustFileBeforeAppend()
            {	
                if ((RollingMode.Size == this.RollingStyle) 
                    && (this.File != null)
                    && (((CountingQuietTextWriter)base.QuietWriter).Count >= this.MaxFileSize)
                    )
                {                   
                    DateTime now = DateTime.Now;
                    String todayFileSuffix = now.ToString(this.DatePattern, CultureInfo.InvariantCulture);
                    String todayFileName = $"{this._baseFileNameWithoutExtension}{todayFileSuffix}{this._baseFileExtension}";
                    String todayFile = Path.Combine(this._folder, todayFileName);
                    if (base.FileExists(todayFile))
                    {                    
                        /* Todays logfile already exist; append content to todays file. */
                        base.CloseFile(); // Close current file in order to allow reading todays file.
                        this.moveContentToTodaysFile(todayFile);
                        // Delete and open todays file for a fresh start.
                        base.DeleteFile(this.File);
                        base.OpenFile(this.File, false);
                    }
                    else
                    {
                        /* Do a roll-over. */
                        
                        base.RollOverSize();
                        
                        using (base.SecurityContext.Impersonate(this))
                        {   
                            this.deleteDepricatedBackupFiles();
                            this.renameBackupFiles(todayFile);
                        }
                    }
                }
                else
                {
                    base.AdjustFileBeforeAppend();
                }
            }
            // Moves the content from the current log file to todays file.
            private void moveContentToTodaysFile(String todayFile)
            {
                using (FileStream logFile = new FileStream(this.File, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (StreamReader reader = new StreamReader(logFile))
                using (FileStream backupFile = new FileStream(todayFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter writer = new StreamWriter(backupFile))
                {
                    const Int32 BUFFER_SIZE = 1024;
                    Char[] buffer = new Char[BUFFER_SIZE];
                    while (true)
                    {
                        Int32 nrOfCharsRead = reader.Read(buffer, 0, BUFFER_SIZE);
                        if (nrOfCharsRead <= 0) { break; }
                                
                        writer.Write(buffer, 0, nrOfCharsRead);
                    }
                }
            }
            // Rename backup files according to the configured date pattern, removing the counter/index suffix.
            private void renameBackupFiles(String todayFile)
            {
                IEnumerable<String> backupFiles = Directory.EnumerateFiles(this._folder, this._backupSearchPattern, SearchOption.TopDirectoryOnly);
                foreach (String backupFile in backupFiles)
                {   
                    base.RollFile(backupFile, todayFile);
                }
            }
            // Keep the number of allowed backup files and delete all others.
            private void deleteDepricatedBackupFiles()
            {
                DirectoryInfo folder = new DirectoryInfo(this._folder);    
                                                    
                IEnumerable<FileInfo> filesToDelete = 
                    folder
                        .EnumerateFiles(this._fileDeletePattern, SearchOption.TopDirectoryOnly)
                        .OrderByDescending(o => o.LastWriteTime)
                        .Skip(this.MaxSizeRollBackups + 1)
                        ;
                foreach (FileSystemInfo fileToDelete in filesToDelete)
                {
                    base.DeleteFile(fileToDelete.FullName);
                }
            }        
        }
    }
