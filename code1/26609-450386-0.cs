        string s = "V‚µ‚¢ŠwK–@‚Ì‚²’ñˆÄ"; // Our japanese are shift-jis encoded, so it appears like garbled
        MailMessage message = new MailMessage();
        message.BodyEncoding = Encoding.GetEncoding("iso-2022-jp");
        message.SubjectEncoding = Encoding.GetEncoding("iso-2022-jp");
        message.Subject = s.ToEncoding(Encoding.GetEncoding("Shift-Jis")); // Change the encoding to whatever your source is
        message.Body = s.ToEncoding(Encoding.GetEncoding("Shift-Jis")); // Change the encoding to whatever your source is
