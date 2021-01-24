    public static void Media_Ended(object sender, EventArgs e)
    {
        if (output.PlaybackState == PlaybackState.Stopped)
        {
            if (ms != null)
            {
                ms.Close();
                ms.Flush();
            }
            if (ms != null)
            {
                ms.Close();
            }
            if (output != null)
            {
                output.Dispose();
            }
        }
    }
