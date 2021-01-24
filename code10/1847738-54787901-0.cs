    public sealed class SampleBackgroundTask2 : IBackgroundTask
        {
    
            EasClientDeviceInformation currentDeviceInfo;
    
            BackgroundTaskCancellationReason _cancelReason = BackgroundTaskCancellationReason.Abort;
    
            BackgroundTaskDeferral _deferral = null;
    
            //
            // The Run method is the entry point of a background task.
            //
            public async void Run(IBackgroundTaskInstance taskInstance)
            {
                currentDeviceInfo = new EasClientDeviceInformation();
    
                var cost = BackgroundWorkCost.CurrentBackgroundWorkCost;
                var settings = ApplicationData.Current.LocalSettings;
                settings.Values["BackgroundWorkCost2"] = cost.ToString();
    
                taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);
    
                _deferral = taskInstance.GetDeferral();
                await asynchronousAPICall();
                _deferral.Complete(); //calling this only when the API call is complete and the toast notification is shown
            }
            private async Task asynchronousAPICall()
            {
                try
                {
                    var httpClient = new HttpClient(new HttpClientHandler());
    
                    string urlPath = (string)ApplicationData.Current.LocalSettings.Values["ServerIPAddress"] + "/Api/Version1/IsUpdatePersonal";
    
                    HttpResponseMessage response = await httpClient.PostAsync(urlPath,
                        new StringContent(JsonConvert.SerializeObject(currentDeviceInfo.Id.ToString()), Encoding.UTF8, "application/json")); // new FormUrlEncodedContent(values)
    
                    response.EnsureSuccessStatusCode();
    
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonText = await response.Content.ReadAsStringAsync();
                        var customObj = JsonConvert.DeserializeObject<bool>(jsonText, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
    
                        if (customObj) // Если TRUE  то да надо сообщить пользователю о необходимости обновления
                        {
                            ShowToastNotification("Ttitle", "Message");
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    _deferral.Complete();
                }
            }
    
            private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
            {
                _cancelReason = reason;
            }
        }
