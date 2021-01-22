    // Instantiate a new SMTP connection to Gmail using TLS/SSL protection.
    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
    smtpClient.Credentials = new NetworkCredential("username@gmail.com", "Pass@word1");
    smtpClient.EnableSsl = true;
 
    // Create a new MailMessage class with lorem ipsum.
    MailMessage message = new MailMessage("username@gmail.com", "user@example.com", "Example subject", "Lorem ipsum body.");
 
    // Specify that the message should be signed, have its envelope encrypted, and then be signed again (triple-wrapped).
    message.SmimeSigned = true;
    message.SmimeEncryptedEnvelope = true;
    message.SmimeTripleWrapped = true;
 
    // Specify that the message should be timestamped.
    message.SmimeSigningOptionFlags = SmimeSigningOptionFlags.SignTime;
 
    // Load the signing certificate from the Local Machine store.            
    message.SmimeSigningCertificate = CertHelper.GetCertificateBySubjectName(StoreLocation.LocalMachine, "username@gmail.com");
 
    // Send the message.
    await smtpClient.SendAsync(message);
