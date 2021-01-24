    public void ConvertIntoZipAndMoveToBackUp(string localPath, string fileName, byte[] zipByteResponse, string code)
        {
            string Destinationpath = Path.Combine(ConfigurationManager.AppSettings["OtherEnrollmentsBackUpPath"], code);
            try
            {               
                fileName = Path.GetFileNameWithoutExtension(fileName) + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss.fff") + ".zip";  //This will ensure that you have a unique filename to create
                File.WriteAllBytes(Path.Combine(localPath, fileName), zipByteResponse);
                lgmr.Log(string.Concat(serviceName, " ", code, ": Zip File Created and Downloaded from the WebAPI Response", Path.Combine(localPath, fileName)), LoggingManager.LogType.Info);
    
                using (var archive = ZipFile.OpenRead(Path.Combine(localPath, fileName)))
                {
                    ecount = archive.Entries.Count(x => !string.IsNullOrWhiteSpace(x.Name));
                    strECount = ecount.ToString();
                    lgmr.Log(string.Concat(serviceName, " ", code, ": Files Count: ",ecount, localPath + "\\" + fileName), LoggingManager.LogType.Info);
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (File.Exists(Path.Combine(localPath, entry.Name)))
                        {
                             File.Delete(Path.Combine(localPath, entry.Name));
                        }
                        entry.ExtractToFile(Path.Combine(localPath, entry.Name));
                    }
                }
    
                File.Move(Path.Combine(localPath, fileName), Path.Combine(Destinationpath, code + string.Format("Enrollments-{0:yyyy-MM-dd_hh-mm-ss.fff}.zip", DateTime.Now)));
            }
            catch (Exception ex)
            {
                //File.Delete(localPath + "\\" + fileName);
                //File.Move(localPath + "\\" + fileName, Destinationpath + "\\" + code + string.Format("ZipErrorEnrollments-{0:yyyy-MM-dd_hh-mm-ss.fff}.zip", DateTime.Now));
                ecount = 0;               
                lgmr.Log(string.Concat(serviceName, " ", code, " ECount:", ecount, ": Failed to ZIP", localPath + "\\" + fileName, "Resend the Request to WebAPI ", ex.Message), LoggingManager.LogType.Info);
                throw ex;
            }
        }
