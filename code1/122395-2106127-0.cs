    count = 0;
            for (int j = 1; j < 255; j++)
                for (int i = 1; i < 255; i++)
                {
                    Ping ping = new Ping();
                    PingReply pingreply = ping.Send(IPAddress.Parse(locip[0] + "." + locip[1] + "." + j + "." + i));
    
                    if (pingreply.Status == IPStatus.Success)
                    {
                        status = "o";
                        repAddress = pingreply.Address.ToString(); ;
                        repRoundtrip = pingreply.RoundtripTime.ToString();
                        repTTL = pingreply.Options.Ttl.ToString();
                        repBuffer = pingreply.Buffer.Length.ToString();
    
                        string[] lineBuffer = { status, repAddress, repRoundtrip, repTTL, repBuffer };
                        ipList.Rows.Add(lineBuffer);
                        count += 1;
                        progressBar.Value += 1;
                    }
                    Application.DoEvents(); //but not too often.
                }
