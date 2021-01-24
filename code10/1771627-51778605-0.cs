    public static async Task<string> GetBackgroundTaskReturnValue(string apiRequestUrl)
    {
            StaticItemsHelper.IsBackgroundPlaylistTaskRunning = true;
            if (StaticItemsHelper.IsBackgroundPlaylistTaskRunning)
            {
                for (int seconds = 0; seconds < 20;)
                {
                    if (!StaticItemsHelper.IsBackgroundPlaylistTaskRunning)
                    {
                        break;
                    }
                    else
                    {
                        Task.Delay(1000).Wait();
                    }
                }
            }
            var request = BackgroundTaskHelper.BackgroundPlaylistTrigger.RequestAsync().GetResults();
            if (request == Windows.ApplicationModel.Background.ApplicationTriggerResult.Allowed)
            {
                SettingsHelper.localSettings.Values[SettingsHelper.BackgroundPlaylistPlaybackURLKey] = apiRequestUrl;
                SettingsHelper.localSettings.Values[SettingsHelper.BackgroundPlaylistPlaybackTokenKey] = StaticItemsHelper.CurrentUserAccessToken;
                if (SettingsHelper.tempFolder.TryGetItemAsync(SettingsHelper.BackgroundPlaylistPlaybackReturnKey).GetResults() is StorageFile file)
                {
                    await file.DeleteAsync();
                }
                for (int seconds = 0; seconds < 30;)
                {
                    if (SettingsHelper.tempFolder.TryGetItemAsync(SettingsHelper.BackgroundPlaylistPlaybackReturnKey).GetResults() is StorageFile _rfile)
                    {
                        var _returnVal = FileIO.ReadTextAsync(_rfile).GetResults();
                        if (!string.IsNullOrEmpty(_returnVal.ToString()))
                        {
                            await _rfile.DeleteAsync();
                            SettingsHelper.localSettings.Values.Remove(SettingsHelper.BackgroundPlaylistPlaybackTokenKey);
                            SettingsHelper.localSettings.Values.Remove(SettingsHelper.BackgroundPlaylistPlaybackURLKey);
                            StaticItemsHelper.IsBackgroundPlaylistTaskRunning = false;
                            return _returnVal;
                        }
                    }
                    Task.Delay(2000).Wait();
                    seconds += 2;
                }
            }
            else if (request == Windows.ApplicationModel.Background.ApplicationTriggerResult.CurrentlyRunning)
            {
                for (int seconds = 0; seconds < 30;)
                {
                    Task.Delay(2000).Wait();
                    seconds += 2;
                    request = BackgroundTaskHelper.BackgroundPlaylistTrigger.RequestAsync().GetResults();
                    if (request == Windows.ApplicationModel.Background.ApplicationTriggerResult.Allowed)
                    {
                        return GetBackgroundTaskReturnValue(apiRequestUrl).Result;
                    }
                }
            }
            if (SettingsHelper.tempFolder.TryGetItemAsync(SettingsHelper.BackgroundPlaylistPlaybackReturnKey).GetResults() is StorageFile _file)
            {
                await _file.DeleteAsync();
            }
            SettingsHelper.localSettings.Values.Remove(SettingsHelper.BackgroundPlaylistPlaybackTokenKey);
            SettingsHelper.localSettings.Values.Remove(SettingsHelper.BackgroundPlaylistPlaybackURLKey);
            StaticItemsHelper.IsBackgroundPlaylistTaskRunning = false;
            return "{ \"error\": {\"code\": \"NetworkError\", \"message\": \"Server returned nothing.\"} }";
    }
