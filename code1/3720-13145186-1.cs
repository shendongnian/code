    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SmtPop;
    
    namespace SMT_POP3
    {
        class Program
        {
            static void Main(string[] args)
            {
                SmtPop.POP3Client pop = new SmtPop.POP3Client();
                pop.Open("<hostURL>", 110, "<username>", "<password>");
    
                // get messages list from pop server
    	        SmtPop.POPMessageId[] messages = pop.GetMailList ();
    		  
    	        if (messages != null)
     	        {
      		        // Walk attachment list
    	  	        foreach (SmtPop.POPMessageId id in messages)
      		        {
    		  	        SmtPop.POPReader reader= pop.GetMailReader(id);
      			        SmtPop.MimeMessage msg= new SmtPop.MimeMessage();
         
      			        // read message
    		  	        msg.Read(reader);
                        if (msg.AddressFrom != null)
                        {
                            String from= msg.AddressFrom[0].Name;
                            Console.WriteLine("from: " + from);
                        }
                        if (msg.Subject != null)
                        {
                            String subject = msg.Subject;
                            Console.WriteLine("subject: "+ subject);
    
                        }
                        if (msg.Body != null)
                        {
                            String body = msg.Body;
                            Console.WriteLine("body: " + body);
    
                        }
    		  	        if (false && msg.Attachments != null)
      			        {
      				        // do something with first attachment
    				        SmtPop.MimeAttachment attach = msg.Attachments[0];
      				        if (attach.Filename == "data")
    		  		        {
      					        // read data from attachment
    			  		        Byte[] b= Convert.FromBase64String(attach.Body);
      					  
      					        System.IO.MemoryStream mem = new System.IO.MemoryStream(b, false);
                                //BinaryFormatter f = new BinaryFormatter();
    					        //DataClass data= (DataClass)f.Deserialize(mem); 
    					        mem.Close();
    				        }						  
    		  			  				
    				        //delete message
    				        //pop.Dele(id.Id);
    
      			        }
      		        }
    	        }
    		
    	        pop.Quit();
            }
        }
    }
