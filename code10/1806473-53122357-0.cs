    [HttpPost]
    public async Task<String> PostProfilePicture(IFormFile file, int ID)
    {
        var name = Guid.NewGuid().ToString("N").ToUpper() + ".png";
        try
        {
            await sendEmail(file, name); //send the file not the open read stream
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    
       return "";
    }
    
    
    
    public async Task sendEmail(IFormFile file, String filename){
    
            using(var stream = file.OpenReadStream()){ //You open your stream here
            var attachment = new Attachment(stream, filename);
    
            var smtpClient = new SmtpClient
    
            {
                Host = "smtp.gmail.com", // set your SMTP server name here
                Port = 587, // Port 
                EnableSsl = true,
                Credentials = new NetworkCredential("xxxxxxx@gmail.com", "xxxxxxxx")
        };
        var message = new MailMessage("xxxxxxx@gmail.com", "xxxxxxx@gmail.com");
            message.Subject = "Hello Alec!!";
            message.Body = "How are you doing.";
            message.Attachments.Add(attachment);
            await smtpClient.SendMailAsync(message);
        }
    }
        }
