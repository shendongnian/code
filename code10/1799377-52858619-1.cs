    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Windows.Forms;
    
    using MimeKit;
    using MimeKit.Cryptography;
    
    namespace ConsoleApplicationSignWithBouncyCastle
    {
        class Program
        {
            [STAThread]
            static void Main (string[] args)
    		{
    			//  Select a binary file
    			var dialog = new OpenFileDialog {
    				Filter = "All files (*.*)|*.*",
    				InitialDirectory = "./",
    				Title = "Select a text file"
    			};
    			var filename = (dialog.ShowDialog () == DialogResult.OK) ? dialog.FileName : null;
                var certificate2 = new X509Certificate2 ("c:/temp1/cert.pfx", "password");
                MimeEntity body;
    
    			using (var content = new MemoryStream (File.ReadAllBytes (filename)))
    			    var part = new MimePart (MimeTypes.GetMimeType (filename)) {
    				    ContentDisposition = new ContentDisposition (ContentDisposition.Attachment),
    				    ContentTransferEncoding = ContentEncoding.Binary,
    				    FileName = Path.GetFileName (filename),
    				    Content = new MimeContent (content)
    			    };
    
    			    var recipient = new CmsRecipient (certificate2) {
                        EncryptionAlgorithms = new EncryptionAlgorithm[] { EncryptionAlgorithm.TripleDes }
                    };
                    var recipients = new CmsRecipientCollection ();
    			    recipients.Add (recipient);
    
                    var signer = new CmsSigner (certificate2) {
    				    DigestAlgorithm = DigestAlgorithm.Sha256
    			    };
    
    			    using (var ctx = new TemporarySecureMimeContext ())
    				    body = ApplicationPkcs7Mime.SignAndEncrypt (ctx, signer, recipients, part);
    			}
    
    			var message = new MimeMessage ();
    			message.Headers.Add ("AS3-From", "PILM");
    			message.Headers.Add ("AS3-To", "SARS");
    			message.Subject = Path.GetFileNameWithoutExtension (filename);
    			message.Date = DateTimeOffset.Now;
    			message.MessageId = "10000003141";
    			message.Body = body;
    
    			var outFile = @"c:\temp1\" + Path.GetFileNameWithoutExtension (filename) + "_w_2.edi";
    			message.WriteTo (outFile);
    		}
        }
    }
