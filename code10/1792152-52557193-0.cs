    catch (Microsoft.WindowsAzure.Storage.StorageException e) when (e.RequestInformation.HttpStatusCode == 409)
            {
                TableResult tableResult = new TableResult();
                tableResult.HttpStatusCode = e.RequestInformation.HttpStatusCode;
                tableResult.Result = e.Message;
                return tableResult;
            }
