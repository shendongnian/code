     //The parameter queryString is only valid for Exchange Server version Exchange2010 or a later version.
            ExchangeService serviceInstance = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            //Provide the  account user credentials
            serviceInstance.Credentials = new WebCredentials(sEmail, sPassword);//ConfigurationManager.AppSettings["Domain"].ToString());
            try
            {
                // Use Autodiscover to set the URL endpoint.
                serviceInstance.AutodiscoverUrl(sEmail, RedirectionUrlValidationCallback); //works up to here
                //error here
                FindItemsResults<Item> items = serviceInstance.FindItems(WellKnownFolderName.Inbox, "to:" + sEmail, new ItemView(15));
                //no error here but can't do a foreach on "items"
                //var items = serviceInstance.FindItems(WellKnownFolderName.Inbox, "to:" + sEmail, new ItemView(15));
                sResult = "Found:" + "\r\n";
                if (items != null)
                {
                    Console.WriteLine(items.Items.Count);
                    foreach (EmailMessage msg in items.Items)
                    {
                        //sResult += msg.Subject + "\r\n";
                        Console.WriteLine(msg.Subject);
                    }
                }
                else
                {
                    Console.WriteLine("is null");
                }
            }
            catch (System.Exception ex)
            {
                serviceInstance = null;
                sResult = ex.Message;
                Console.WriteLine(sResult);
            }
            Console.WriteLine("fhdfhk");
            Console.ReadKey();
