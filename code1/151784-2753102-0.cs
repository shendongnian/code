    using System;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private readonly WebClient wcUploader = new WebClient();
    
            public Form1()
            {
                InitializeComponent();
    
                wcUploader.UploadFileCompleted += UploadFileCompletedCallback;
                wcUploader.UploadProgressChanged += UploadProgressCallback;
            }
    
    
            private void UploadFileCompletedCallback(object sender, UploadFileCompletedEventArgs e)
            {
                // a clever way to handle cross-thread calls and avoid the dreaded
                // "Cross-thread operation not valid: Control 'textBox1' accessed 
                // from a thread other than the thread it was created on." exception
    
                // this will always be called from another thread,
                // no need to check for InvokeRequired
                textBox1.BeginInvoke(
                    new MethodInvoker(() =>
                        {
                            textBox1.Text = Encoding.UTF8.GetString(e.Result);
                            button1.Enabled = true;
                        }));
            }
    
            private void UploadProgressCallback(object sender, UploadProgressChangedEventArgs e)
            {
                // a clever way to handle cross-thread calls and avoid the dreaded
                // "Cross-thread operation not valid: Control 'textBox1' accessed 
                // from a thread other than the thread it was created on." exception
    
                // this will always be called from another thread,
                // no need to check for InvokeRequired
    
                textBox1.BeginInvoke(
                    new MethodInvoker(() =>
                        {
                            textBox1.Text = (string) e.UserState + "\n\n"
                                            + "Uploaded " + e.BytesSent + "/" + e.TotalBytesToSend
                                            + "b (" + e.ProgressPercentage + "%)";
                        }));
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                textBox1.Text = "";
    
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    button1.Enabled = false;
                    string toUpload = openFileDialog1.FileName;
                    textBox1.Text = "Initiating connection";
                    new Thread(() =>
                               wcUploader.UploadFileAsync(new Uri("http://anyhub.net/api/upload"), "POST", toUpload)).Start();
                }
            }
        }
    }
