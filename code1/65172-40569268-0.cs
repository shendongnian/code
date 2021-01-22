    using System.Management;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Net.NetworkInformation;
    using System.Diagnostics;
    using SnmpSharpNet;
        private bool getSnmp(string host, string OID)
        {
            bool result = false;
            /* Get an SNMP Object
            */
            SimpleSnmp snmpVerb = new SimpleSnmp(host, 161, "public", 20, 0);
            if (!snmpVerb.Valid)
            {
                //MessageBox.Show("Seems that IP or comunauty is not cool");
                return result;
            }
            Oid varbind = new Oid(OID);
            
            Dictionary<Oid, AsnType> snmpDataS = snmpVerb.Get(SnmpVersion.Ver1, new string[] { varbind.ToString() });
            if (snmpDataS != null)
            {
                this.Invoke((MethodInvoker)(() => lstBoxPrinters.Items.Add(
                    string.Format("{0} : {1}", host, snmpDataS[varbind].ToString()))));
                result = true;
            }
            else
                Console.WriteLine("Not Response from " + host);
            return result;
        }
        private void p_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            string ip = (string)e.UserState;
            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                /* PRINTER-PORT-MONITOR-MIB - 1.3.6.1.4.1.2699
                 * ppmPrinterIEEE1284DeviceId: 1.3.6.1.4.1.2699.1.2.1.2.1.1.3
                 */
                getSnmp(ip, "1.3.6.1.4.1.2699.1.2.1.2.1.1.3.1");
            }
            else if (e.Reply == null)
            {
                Console.WriteLine("Pinging {0} failed. (Null Reply object?)", ip);
            }
            countdown.Signal();
        }
        private void ScanPrinters()
        {
            countdown = new CountdownEvent(1);
            Stopwatch sw = new Stopwatch();
            sw.Start();            
            string ipBase = "192.168.1.";            
            for (int i = 1; i < 254; i++)
            {
                string ip = ipBase + i.ToString();
                Ping p = new Ping();
                p.PingCompleted += new PingCompletedEventHandler(p_PingCompleted);
                countdown.AddCount();
                p.SendAsync(ip, 100, ip);
            }
            countdown.Signal();
            countdown.Wait();
            sw.Stop();
            // For some reason is needed call Refresh() twice
            this.Invoke((MethodInvoker)(() => lstBoxPrinters.Refresh()));
            //this.Invoke((MethodInvoker)(() => lstBoxPrinters.Refresh()));
            MessageBox.Show("Printer scan finished");
        }
        private async void btSearchAgain_Click(object sender, EventArgs e)
        {
            lstBoxPrinters.Items.Clear();
            //PrinterList();
            /******/
            Task task = Task.Run(() => ScanPrinters());
            await task;
            /******/
        }
