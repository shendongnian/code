    static void Main(string[] args)
        {
            Notifications notifications = new Notifications()
            {
                ActionId = "actionId",
                EnterpriseUrl = "enterpriceUri",
                PartnerUrl = "parentUri",
                Notification = new Notification
                {
                    Id = "abc",
                    SObject = new SObject
                    {
                        Email = "email",
                        Id = "id",
                        Sf = "sf",
                        Student_ID__c = "a",
                        Type = "type"
                    }
                }
            };
            Message me = Message.CreateMessage(MessageVersion.Soap11, "www.abc.com", notifications);  // create a message and serialize the notifications into the message
            WriteMessage(me, @"d:\message.xml");
        }
        static void WriteMessage(Message message, string fileName)
        {
            using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                message.WriteMessage(writer);// write the message into a file
            }
            Process.Start(fileName);// show the file
        }
