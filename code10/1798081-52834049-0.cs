    private void Server_DelimiterReceived(object sender, SimpleTCP.Message e, TcpClient client)
    {
        listView1.Invoke((MethodInvoker)delegate ()
        {
            string json = e.MessageString;
            S3Object s3obj = JsonConvert.DeserializeObject<S3Object>(json);
            ListViewItem lv = new ListViewItem(s3obj.id);
            lv.SubItems.Add(s3obj.bucket);
            lv.SubItems.Add(s3obj.objects);
            listView1.Items.Add(lv);
            TcpClient client = e.TcpClient;
            // do something with the client...
        });
    }
