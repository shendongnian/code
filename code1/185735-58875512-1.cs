            /// <summary>
            /// Sets clipboard to value.
            /// </summary>
            /// <param name="value">String to set the clipboard to.</param>
            public static void SetClipboard(string value)
            {
                if (value == null)
                    throw new ArgumentNullException("Attempt to set clipboard with null");
                Process clipboardExecutable = new Process(); 
                clipboardExecutable.StartInfo = new ProcessStartInfo // Creates the process
                {
                    RedirectStandardInput = true,
                    FileName = @"clip", 
                };
                clipboardExecutable.Start();
                clipboardExecutable.StandardInput.Write(value); // CLIP uses STDIN as input.
                // When we are done putting all the string, close it so it clip doesn't wait and get stuck
                clipboardExecutable.StandardInput.Close(); 
                return;
            }
