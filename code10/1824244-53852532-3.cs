    static void Main(string[] args)
            {
                var service = ConnectionToEws.ConnectToService();
                var results = service.FindItems(WellKnownFolderName.Inbox, new ItemView(1));
                foreach (var item in results)
                {
                    var originalId = new AlternateId(IdFormat.EwsId, item.Id.ToString(), "EmailAddress", false);
                    var entryId = service.ConvertId(originalId, IdFormat.HexEntryId);
                    Console.WriteLine(((AlternateId)entryId).UniqueId);
                }
                Console.ReadKey();
            }
