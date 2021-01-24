    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
     
    namespace ServerComputer
    {
        publicpartialclassmainForm : Form
        {
            public mainForm()
            {
                InitializeComponent();
            }
            Socket sendsocket;
            privatevoid goLive_Click(object sender, EventArgs e)
            {
                try
                {
                    sendsocket = newSocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //The instantiation of socket, IP for 192.168.1.106, 10001 for PortIPEndPoint ipendpiont = newIPEndPoint(IPAddress.Parse(ipAddress.Text.Trim()), 10001);
                    sendsocket.Connect(ipendpiont);
                    //Establishment of end pointThread th = newThread(newThreadStart(threadimage));
                    th.IsBackground = true;
                    th.Start();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    return;
                }
                this.Hide();    //Hidden form
            }
            privateBitmap GetScreen()
            {
                Bitmap bitmap = newBitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                return bitmap;
            }
            privatevoid threadimage()
            {
                try
                {
                    MemoryStream ms = newMemoryStream();
                    GetScreen().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);   //Here I use the BMP formatbyte[] b = ms.ToArray();
     
                    sendsocket.Send(b);
                    ms.Close();
     
     
                }
                catch (Exception ee)
                {
                    // MessageBox.Show(ee.Message);//return;
                }
     
                Thread.Sleep(1000);
                threadimage();
            }
        }
    }
