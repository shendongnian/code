                    excelPack.SaveAs(new FileInfo(name));                                                          
                    File.SetAttributes(name, FileAttributes.ReadOnly); //Force the user to save file As                                        
                    System.Diagnostics.Process.Start(name);
                    File.SetAttributes(name, FileAttributes.Normal);                                                                     
                    File.Delete(name); 
