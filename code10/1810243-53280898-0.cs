    // POP3 server information.
    const string serverName = "myserver";
    const string user = "name@domain.com";
    const string password = "mytestpassword";
    const int port = 995;
    const SecurityMode securityMode = SecurityMode.Implicit;
    // Create a new instance of the Pop3Client class.
    Pop3Client client = new Pop3Client();
    Console.WriteLine("Connecting Pop3 server: {0}:{1}...", serverName, port);
    // Connect to the server.
    client.Connect(serverName, port, securityMode);
    // Login to the server.
    Console.WriteLine("Logging in as {0}...", user);
    client.Authenticate(user, password);
    // Initialize BounceInspector.
    BounceInspector inspector = new BounceInspector();
    inspector.AllowInboxDelete = false; // true if you want BounceInspector automatically delete all hard bounces.
    // Register processed event handler.
    inspector.Processed += inspector_Processed;
    // Download messages from Pop3 Inbox to 'c:\test' and process them.
    BounceResultCollection result = inspector.ProcessMessages(client, "c:\\test");
    // Display processed emails.
    foreach (BounceResult r in result)
    {
       // If this message was identified as a bounced email message.
       if (r.Identified)
       {
           // Print out the result
           Console.Write("FileName: {0}\nSubject: {1}\nAddress: {2}\nBounce Category: {3}\nBounce Type: {4}\nDeleted: {5}\nDSN Action: {6}\nDSN Diagnostic Code: {7}\n\n",
                           System.IO.Path.GetFileName(r.FilePath),
                           r.MailMessage.Subject,
                           r.Addresses[0],
                           r.BounceCategory.Name,
                           r.BounceType.Name,
                           r.FileDeleted,
                           r.Dsn.Action,
                           r.Dsn.DiagnosticCode);
       }
    }
    Console.WriteLine("{0} bounced message found", result.BounceCount);
    // Disconnect.
    Console.WriteLine("Disconnecting...");
    client.Disconnect();
