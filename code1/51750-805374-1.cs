                    private void SetWallpaper(string path)
                    {
                        if (File.Exists(path))
                        {
                            Image imgInFile = Image.FromFile(path);
                            try
                            {
                                imgInFile.Save(SaveFile, ImageFormat.Bmp);
                                SystemParametersInfo(SPI_SETDESKWALLPAPER, 3, SaveFile, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
                            }
                            catch
                            {
                                MessageBox.Show("error in setting the wallpaper");
                            }
                            finally
                            {
                                imgInFile.Dispose();
                            }
                        }
                        
                        Else
                        {
                              messagebox.show("Error with path: "+path+" Not found or in use");
                        }
                    }
