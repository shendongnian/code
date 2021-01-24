    public static class Mail
    {
           private static int mailCount;
    
           public static void MailSent()
           {
              mailCount++;
           }
    
           public static int GetMailCount()
           {
              return mailCount;
           }
    }
