    public class EmailReportManager 
    { 
        private List<string> emailAddresses = null; 
 
        public EmailReportManager(string emailAddressesCommaSeperatedList) 
        { 
            this.emailAddresses.AddRange(emailAddressesCommaSeperatedList.Split(","))
        } 
    } 
