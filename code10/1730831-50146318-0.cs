    using System.ComponentModel;
    private void connect()
    {
        using(BackgroundWorker bw = new BackgroundWorker())
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.Connect(ip, port);
            bw.DoWork += (o, e) => {
                sendRawPackets(sock, "<policy-file-request/>");
                Thread.Sleep(600);
                sendRawPackets(sock, "<msg t='sys'><body action='verChk' r='0'><ver v='154' /></body></msg>");
                Thread.Sleep(600);
                sendRawPackets(sock, "<msg t='sys'><body action='login' r='0'><login z='Slime'><nick><![CDATA[" + user.Text + "]]></nick><pword><![CDATA[" + logkey + "]]></pword></login></body></msg>");
                Thread.Sleep(600);
                sendRawPackets(sock, "%xt%login%1#2%-2");
                Thread.Sleep(600);
                sendRawPackets(sock, "%xt%login%2#6%-1%");
                Thread.Sleep(600);
                sendRawPackets(sock, "%xt%login%2#7%17610%69%0,-255,190%");
                Thread.Sleep(600);
                sendRawPackets(sock, "%xt%login%2#4%3150%FlumsFountain%52.9941101744771%0%989.1726320236921%-180%0%190%");
                Thread.Sleep(600);
            }
            bw.RunWorkerCompleted += (o, e) => {
                //When all the work is finished
            }
            //Runs the background worker
            bw.RunWorkerAsync();
        }
        
    }
