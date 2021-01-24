                    double ContentLength = 0;
                    double result;
                    if (double.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
                    {
                        string File_Size;
                        if (ContentLength >= 1073741824.00)
                        {
                            result = ContentLength / 1073741824.00;
                            kbmbgb.Text = "GB";
                        }
                        else if (ContentLength >= 1048576.00)
                        {
                            result = ContentLength / 1048576.00;
                            kbmbgb.Text = "MB";
                        }
                        else if (ContentLength >= 1024.00)
                        {
                            result = ContentLength / 1024.00;
                            kbmbgb.Text = "KB";
                        }
                        else
                        {
                            result = ContentLength;
                            kbmbgb.Text = "BYTE";
                        
                        }
                        File_Size = result.ToString("0.00");
                        sizevaluelabel.Text = File_Size;
