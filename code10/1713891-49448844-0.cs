                ContentResolver rc = ContentResolver;
                var stream = rc.OpenInputStream(data.Data);
                try
                {
                    using (var fileStream = System.IO.File.Create(filepath))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("exception :" + ex.Message);
                }
