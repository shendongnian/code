    public static void Main() {
        bool readInProgress = false;
        System.IAsyncResult result = null;
        var stop_waiting = new System.Threading.ManualResetEvent(false);
        byte[] buffer = new byte[256];
        var s = System.Console.OpenStandardInput();
        while (true) {
            if (!readInProgress) {
                readInProgress = true;
                result = s.BeginRead(buffer, 0, buffer.Length
                  , ar => stop_waiting.Set(), null);
            }
            bool signaled = true;
            if (!result.IsCompleted) {
                stop_waiting.Reset();
                signaled = stop_waiting.WaitOne(5000);
            }
            else {
                signaled = true;
            }
            if (signaled) {
                readInProgress = false;
                int numBytes = s.EndRead(result);
                string text = System.Text.Encoding.UTF8.GetString(buffer
                  , 0, numBytes);
                System.Console.Out.Write(string.Format(
                  "Thank you for typing: {0}", text));
            }
            else {
                System.Console.Out.WriteLine("oy, type something!");
            }
        }
