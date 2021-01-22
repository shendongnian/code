    public class Form1 : Form
    {
        private object download1Result;
        private object download2Result;
        private void BeginDownload()
        {
            // Next two lines are only necessary if this is called multiple times
            download1Result = null;
            download2Result = null;
            bwDownload1.RunWorkerAsync();
            bwDownload2.RunWorkerAsync();
        }
        private void bwDownload1_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            download1Result = e.Result;
            if (download2Result != null)
                DisplayResults();
        }
        private void bwDownload2_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            download2Result = e.Result;
            if (download1Result != null)
                DisplayResults();
        }
        private void DisplayResults()
        {
            // Do something with download1Result and download2Result
        }
    }
