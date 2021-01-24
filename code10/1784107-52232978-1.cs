    private async void button1_Click(object sender, EventArgs e)
    {
       _stopLoop = false;
    
       while( !_stopLoop)
       {  
          using (var p = new Ping())
          {
             var pingReply = await p.SendPingAsync(IPAddress.Parse("1.1.1.1"), 10000);
             lbPing.Text = $"{pingReply.RoundtripTime} ms";
             await Task.Delay(1000);
          }
       }
    }
