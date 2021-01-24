    using System;
    using SendGrid.Helpers.Mail;
    using Microsoft.Azure.WebJobs.Host;
    
    namespace YourProject
    {
    	public class TempClass
    	{
    		public static Mail Run(TimerInfo myTimer, TraceWriter log)
    		{
    			var today = DateTime.Today.ToShortDateString();
    			log.Info($"Generating daily report for {today} at {DateTime.Now}");
    
    			Mail message = new Mail()
    			{
    				Subject = "15 DK'LIK TEST MAILI"
    			};
    
    			Content content = new Content
    			{
    				Type = "text/plain",
    				Value = "Bu mail 15 dk da bir yinelenecektir."
    			};
    
    			message.AddContent(content);
    			return message;
    		}
    	}
    }
