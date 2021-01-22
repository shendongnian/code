    /// <summary>
            /// Encryps given file using PGP Public Key
            /// </summary>
            /// <param name="filename"></param>
            public string Encrypt(string filename, bool isBinary, ref string outstr){
    
                string outputfilename = filename;
               
    
                //We use stringbuilder for performance considerations
                StringBuilder sb = new StringBuilder();
                sb.Append("/c ");
                sb.Append("");
                sb.Append(PGPLocation);
                sb.Append(" +force -es ");
                sb.Append("\"");
                sb.Append(filename);
                sb.Append("\" ");
                sb.Append(ToUserName);
                sb.Append(" -u ");
                sb.Append(MyUserName);
                
                sb.Append(" -z ");
                sb.Append(PassPhrase);
                sb.Append(" ");
                
                // Use binary indicator because PGP produces different outputs for binary and plain text files
                if (isBinary)
                    sb.Append("-a");
          
                proc.StartInfo.Arguments = sb.ToString();
             
    
                //proc.StartInfo.Arguments = "/c pgp +force -es "+filename+" cumacam -u bugra";
                
               
                proc.Start();
                if (WaitForInfinity)
                    proc.WaitForExit();
                else
                    proc.WaitForExit(WaitTime);
                //string res = proc.StandardOutput.ReadToEnd();
    
                outstr = proc.StartInfo.Arguments;
                if (proc.HasExited)
                {
                    int ab = proc.ExitCode;
                    if (ab != 0)
                    {
                        FireError(Convert.ToInt32(ErrorTypes.PGPEncryptError), "Erro No: " + ab.ToString() + "in PGP. Details: "+" "+proc.StandardOutput.ReadToEnd());
                        return null;
                    }
                    else
                        if (!isBinary)
                            return outputfilename+".pgp";
                    return outputfilename + ".asc";
                }
                
                return null;
            }
