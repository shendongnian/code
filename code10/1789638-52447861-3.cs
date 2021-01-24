    if (((int)response.StatusCode == 429) || ((int)response.StatusCode == 503))
                {
                    // Retry Only After the server specified time period obtained from the response.
                    TimeSpan pauseDuration = TimeSpan.FromSeconds(Math.Pow(2, attempt));
                    TimeSpan serverRecommendedPauseDuration = GetServerRecommendedPause(response);
                    if (serverRecommendedPauseDuration > pauseDuration)
                    {
                        pauseDuration = serverRecommendedPauseDuration;
                    }
