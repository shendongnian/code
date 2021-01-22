    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Net;
    using System.IO;
    namespace testSSL
    {
        public partial class FormDownload : Form
        {
            private bool success;
            private const string filename = "file.txt";
            private const string url_string = "https://some.url.com";
            private Uri url;
        public FormDownload()
        {
            InitializeComponent();
            success = false;
            url = new Uri(url_string);
        }
        public bool StartDownload()
        {
            this.ShowDialog();
            return success;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Activate();
            progressBar1.Maximum = 100;
            label1.Text = "Working";
            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            
            //possible fix for running on w2k
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            string user="user", pass="pass";
            client.Credentials = new NetworkCredential(user, pass);
            try
            {
                client.DownloadFileAsync(url, filename);
            }
            catch (Exception ue)
            {
                writeException(ue.Message);
            }
             
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                writeException(e.Error.Message);
                success = false;
            }
            else
            {
                label1.Text = "Done";
                System.Threading.Thread.Sleep(100);
                success = true;
            }
            this.Close();
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void writeException(string ex)
        {
            ex = "Date: " + DateTime.Now.ToString() + " Exception: " + ex + "\r\n";
            File.AppendAllText("downloadLog.txt", ex);
            MessageBox.Show("An error has occurred; it has been logged");
            this.Close();
        }
    }
}
