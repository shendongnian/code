    using System;
    using System.Net;
    using System.Net.Mail;
    namespace RSS.SmtpTest
    {
        class Program
        {
            static void Main( string[] args )
            {
                try {
                    using( SmtpClient smtpClient = new SmtpClient( "localhost", 465 ) ) { // <-- note the use of localhost
                        NetworkCredential creds = new NetworkCredential( "username", "password" );
                        smtpClient.Credentials = creds;
                        MailMessage msg = new MailMessage( "joe@schmoe.com", "jane@schmoe.com", "Test", "This is a test" );
                        smtpClient.Send( msg );
                    }
                }
                catch( Exception ex ) {
                    Console.WriteLine( ex.Message );
                }
            }
        }
    }
