    // This allows the clipboard to have something copied to it.
        public static void ClipboardPaste(String pasteString)
        {
            // This clears the clipboard
            Clipboard.Clear();
            // This is a "Try" of the statement inside {}, if it fails it goes to "Catch"
            // If it "Catches" an exception. Then the function will retry itself.
            try
            {
                // This, per some suggestions I found is a half second second wait before another
                // clipboard clear and before setting the clipboard
                System.Threading.Thread.Sleep(500);
                Clipboard.Clear();
                // This is, instead of using SetText another method to put something into
                // the clipboard, it includes a retry/fail set up with a delay
                // It retries 5 times with 250 milliseconds (0.25 second) between each retry.
                Clipboard.SetDataObject(pasteString, false, 5, 250);
            }
            catch (Exception)
            {
                ClipboardPaste(pasteString);
            }
        }
