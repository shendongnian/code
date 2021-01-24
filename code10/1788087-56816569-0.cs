     _cancelTasks = new CancellationTokenSource();
            string Response = null;
            var task = new Task(() => {
                try
                {
                    using (var wb = new WebClient())
                    {
                        var data = new NameValueCollection();
                        data["XMLString"] = XMLRequest;
                        var response = wb.UploadValues(ServiceURL, "POST", data);
                   
                    }
                }
                catch (Exception ex)
                {
                }
            }, _cancelTasks.Token);
            task.Start();
            if (!task.Wait(GWRequestTimeout * 1000))
            {
              
                _cancelTasks.Cancel();
            }
