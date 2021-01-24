        static async Task RunUserTimelineQueryAsync(TwitterContext twitterCtx)
        {
            //List<Status> tweets =
            //    await
            //    (from tweet in twitterCtx.Status
            //     where tweet.Type == StatusType.User &&
            //           tweet.ScreenName == "JoeMayo"
            //     select tweet)
            //    .ToListAsync();
            const int MaxTweetsToReturn = 200;
            const int MaxTotalResults = 100;
            // oldest id you already have for this search term
            ulong sinceID = 1;
            // used after the first query to track current session
            ulong maxID;
            var combinedSearchResults = new List<Status>();
            List<Status> tweets =
                await
                (from tweet in twitterCtx.Status
                 where tweet.Type == StatusType.User &&
                       tweet.ScreenName == "JoeMayo" &&
                       tweet.Count == MaxTweetsToReturn &&
                       tweet.SinceID == sinceID &&
                       tweet.TweetMode == TweetMode.Extended
                 select tweet)
                .ToListAsync();
            if (tweets != null)
            {
                combinedSearchResults.AddRange(tweets);
                ulong previousMaxID = ulong.MaxValue;
                do
                {
                    // one less than the newest id you've just queried
                    maxID = tweets.Min(status => status.StatusID) - 1;
                    Debug.Assert(maxID < previousMaxID);
                    previousMaxID = maxID;
                    tweets =
                        await
                        (from tweet in twitterCtx.Status
                         where tweet.Type == StatusType.User &&
                               tweet.ScreenName == "JoeMayo" &&
                               tweet.Count == MaxTweetsToReturn &&
                               tweet.MaxID == maxID &&
                               tweet.SinceID == sinceID &&
                               tweet.TweetMode == TweetMode.Extended
                         select tweet)
                        .ToListAsync();
                    combinedSearchResults.AddRange(tweets);
                } while (tweets.Any() && combinedSearchResults.Count < MaxTotalResults);
                PrintTweetsResults(tweets);
            }
            else
            {
                Console.WriteLine("No entries found.");
            }
        }
