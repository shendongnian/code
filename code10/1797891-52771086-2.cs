    	public class EmailNotificationAdapter implements ForNotifyingClients {
   			private final EmailSystem emailSystem;
   			
   			// Inject the email system interface you want to use in the adapter constructor
    		public EmailNotificationAdapter ( EmailSystem emailSystem ) {
    			this.emailSystem = emailSystem;
    		}
    		// Implements the method using the email system to send an email
    		@Override
    		public void sendPurchaseOrderConfirmation ( String recipient ) {
    			// ...code that sends an email to the recipient using this.emailSystem
    		}
    	}
