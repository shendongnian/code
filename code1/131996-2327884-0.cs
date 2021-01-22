    // create client and connect 
    Ftp client = new Ftp();
    client.Connect("ftp.example.org");
    client.Login("username", "password");
    
    // send SITE command
    // note that QUOTE and SITE are ommited. QUOTE is command line ftp syntax only.
    client.Site("LRECL=132 RECFM=FB");
    // send SYST command
    client.SendCommand("SYST");
    FtpResponse response = client.ReadResponse();
    if (response.Group != 2) 
      ; // handle error 
    
    // disconnect 
    client.Disconnect();
