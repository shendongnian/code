                //[snip]
                int iteration = 0, charsRead;
                while ((charsRead = reader.Read(charBuffer, 0, bufferSize)) > 0)
                {
                    sb.Append(charBuffer, 0, charsRead);
                    //Some progress calculation
                    if((++iteration % 20) == 0 && Progress != null) {
                        Progress(iProgressPercentage);
                    }
                }
                //[snip]
