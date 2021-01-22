    using Rebex.Mail;
    using Rebex.Mime.Headers;
    using Rebex.Security.Certificates;
    ...
    
    // load the sender's certificate and 
    // associated private key from a file 
    Certificate signer = Certificate.LoadPfx("hugo.pfx", "password");
    
    // load the recipient's certificate 
    Certificate recipient = Certificate.LoadDer("joe.cer");
    
    // create an instance of MailMessage 
    MailMessage message = new MailMessage();
    
    // set its properties to desired values 
    message.From = "hugo@example.com";
    message.To = "joe@example.com";
    message.Subject = "This is a simple message";
    message.BodyText = "Hello, Joe!";
    message.BodyHtml = "Hello, <b>Joe</b>!";
    
    // sign the message using Hugo's certificate 
    message.Sign(signer);
    
    // and encrypt it using Joe's certificate 
    message.Encrypt(recipient);
    
    // if you wanted Hugo to be able to read the message later as well, 
    // you can encrypt it for Hugo as well instead - comment out the previous 
    // encrypt and uncomment this one: 
    // message.Encrypt(recipient, signer) 
