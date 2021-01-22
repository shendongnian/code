        static void Main(string[] args)
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            service.Credentials = new NetworkCredential("Active Dir ID", "password", "domain name");
            service.AutodiscoverUrl("user@domain.com");
            FindItemsResults<Item> findResults = service.FindItems(
                WellKnownFolderName.Inbox,
                new ItemView(10));
            foreach (Item item in findResults.Items)
                Console.WriteLine(item.Subject);
        }
