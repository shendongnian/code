            long size, start, end, length, fp = 0;
            byte[] buffer = new byte[10000];
            int ilength = 0;
            using (Stream reader = new FileStream(fullpath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                size = reader.Length;
                start = 0;
                end = size - 1;
                length = size;
                context.Response.AddHeader("Accept-Ranges", "0-" + size);
                if (!String.IsNullOrEmpty(context.Request.ServerVariables["HTTP_RANGE"]))
                {
                    long anotherStart = start;
                    long anotherEnd = end;
                    string[] arr_split = context.Request.ServerVariables["HTTP_RANGE"].Split(new char[] { Convert.ToChar("=") });
                    string range = arr_split[1];
                    // Make sure the client hasn't sent us a multibyte range
                    if (range.IndexOf(",") > -1)
                    {
                        context.Response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + size);
                        throw new HttpException(416, "Requested Range Not Satisfiable");
                    }
                    // If the range starts with an '-' we start from the beginning
                    // If not, we forward the file pointer
                    // And make sure to get the end byte if spesified
                    if (range.StartsWith("-"))
                    {
                        // The n-number of the last bytes is requested
                        anotherStart = size - Convert.ToInt64(range.Substring(1));
                    }
                    else
                    {
                        arr_split = range.Split(new char[] { Convert.ToChar("-") });
                        anotherStart = Convert.ToInt64(arr_split[0]);
                        long temp = 0;
                        anotherEnd = (arr_split.Length > 1 && Int64.TryParse(arr_split[1].ToString(), out temp)) ? Convert.ToInt64(arr_split[1]) : size;
                    }
                    // End bytes can not be larger than $end.
                    anotherEnd = (anotherEnd > end) ? end : anotherEnd;
                    // Validate the requested range and return an error if it's not correct.
                    if (anotherStart > anotherEnd || anotherStart > size - 1 || anotherEnd >= size)
                    {
                        context.Response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + size);
                        throw new HttpException(416, "Requested Range Not Satisfiable");
                    }
                    start = anotherStart;
                    end = anotherEnd;
                    length = end - start + 1; // Calculate new content length
                    fp = reader.Seek(start, SeekOrigin.Begin);
                    context.Response.StatusCode = 206;
                    ilength = reader.Read(buffer, 0, 10000);
                    reader.Dispose();
                    reader.Close();
                }
            }
            // Notify the client the byte range we'll be outputting
            context.Response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + size);
            context.Response.AddHeader("Content-Length", length.ToString());
            // Start buffered download
            context.Response.OutputStream.Write(buffer, 0, ilength);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
