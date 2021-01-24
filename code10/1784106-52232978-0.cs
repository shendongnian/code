    private async void button1_Click(object sender, EventArgs e)
    {
       _stopLoop = false;
    
       while( !_stopLoop)
       {  
          using (var p = new Ping())
          {
             lbPing.Text = (await p.SendPingAsync(IPAddress.Parse("1.1.1.1"), 10000)).RoundtripTime + "ms\n";
             await Task.Delay(1000);
          }
       }
    }
