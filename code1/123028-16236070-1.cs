            /// <summary>
            /// Extract all fonts from PDF
            /// </summary>
            /// <param name="strPDFName"></param>
            public static void ExtractAll(string strPDFName)
            {
                if (strMUTOOL != null && strFontFinal != null)
                {
                    Process p = new Process();
                    p.StartInfo.FileName = strMUTOOL;
                    p.StartInfo.Arguments = "extract \"" + strPDFName + "\"";
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.WorkingDirectory = strMUTOOL.Replace("mutool.exe", "").Trim();
                    p.Start();
                    p.WaitForExit();
                    var standardError = p.StandardError.ReadToEnd();
                    var standardOutput = p.StandardOutput.ReadToEnd();
                    var exitCode = p.ExitCode;
                }
            }
