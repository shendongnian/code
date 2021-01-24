            DataTransfer dataXfer2 = new DataTransfer()
            {
                Kind = "admin#datatransfer#DataTransfer",
                OldOwnerUserId = olduser.Id,
                NewOwnerUserId = newuser.Id,
                ApplicationDataTransfers = new List<ApplicationDataTransfer>()
            };
            
            ApplicationDataTransfer item = new ApplicationDataTransfer()
            {
                ApplicationId = (long)55656082996,
                ApplicationTransferParams = new List<ApplicationTransferParam>()
            };
            item.ApplicationTransferParams.Add(new ApplicationTransferParam()
            {
                Key = "PRIVACY_LEVEL",
                Value =
                    new List<string>() { "PRIVATE",
                "SHARED" }
            });
            dataXfer2.ApplicationDataTransfers.Add(item);
            Console.WriteLine("Starting Data transfer from " + oldowner + " to " + newowner);
            TransfersResource.InsertRequest req = dtservice.Transfers.Insert(dataXfer2);
            
            var resp2=req.Execute();
            Console.WriteLine("Initial OverTransferStatusCode = " + resp2.OverallTransferStatusCode);
            Console.WriteLine("TransferID = " + dataXfer2.Id); 
