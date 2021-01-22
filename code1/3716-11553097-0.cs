    using (Pop3Client cl = new Pop3Client()) 
    { 
        cl.UserName = "MyUserName"; 
        cl.Password = "MyPassword"; 
        cl.ServerName = "MyServer"; 
        cl.AuthenticateMode = Pop3AuthenticateMode.Pop; 
        cl.Ssl = false; 
        cl.Authenticate(); 
        ///Get first mail of my mailbox 
        Pop3Message mg = cl.GetMessage(1); 
        String MyText = mg.BodyText; 
        ///If the message have one attachment 
        Pop3Content ct = mg.Contents[0];         
        ///you can save it to local disk 
        ct.DecodeData("your file path"); 
    } 
