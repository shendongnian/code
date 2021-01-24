            var allFollowerIds = new List<ulong>();
            Friendship followers;
            long cursor = -1;
            do
            {
                try
                {
                    followers =
                        await
                        (from follower in twitterCtx.Friendship
                         where follower.Type == FriendshipType.FollowerIDs &&
                               follower.UserID == "15411837" &&
                               follower.Cursor == cursor &&
                               follower.Count == 200
                         select follower)
                        .SingleOrDefaultAsync();
                }
                catch (TwitterQueryException tqe)
                {
                    Console.WriteLine(tqe.ToString());
                    break;
                }
                if (followers != null &&
                    followers.IDInfo != null &&
                    followers.IDInfo.IDs != null)
                {
                    cursor = followers.CursorMovement.Next;
                    allFollowerIds.AddRange(followers.IDInfo.IDs);
                }
            } while (cursor != 0);
            cursor = -1;
            foreach (var uid in allFollowerIds)
            {
                Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " - *** Start Friend Get for " + uid.ToString() + " ***");
                do
                {
                    var friendList = await (from friend in twitterCtx.Friendship where friend.Type == FriendshipType.FriendIDs && friend.UserID == uid.ToString() && friend.Cursor == cursor select friend).SingleOrDefaultAsync();
                    if (twitterCtx.RateLimitRemaining <= 2)
                    {
                        Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " - *** Pausing A ***");
                        Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " - Friends Rate Limit Remaining at Pause A: " +
                          twitterCtx.RateLimitRemaining.ToString());
                        //PauseThatRefreshes("friends");
                    }
                    if (friendList != null &&
                      friendList.IDInfo != null &&
                      friendList.IDInfo.IDs != null)
                    {
                        cursor = friendList.CursorMovement.Next;
                        Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " - Friends Rate Limit Remaining: " + twitterCtx.RateLimitRemaining.ToString());
                        //friendList.IDInfo.IDs.ForEach(id => Output(uid.ToString(), id.ToString()));
                    }
                    if (twitterCtx.RateLimitRemaining <= 2)
                    {
                        Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " - *** Pause B ***");
                        Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " - Friends Rate Limit Remaining at Pause B: " + twitterCtx.RateLimitRemaining.ToString());
                        //PauseThatRefreshes("friends");
                    }
                } while (cursor != 0);
                Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " - *** Stop Friend Get for " + uid.ToString() + " ***");
                Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " - Friends Rate Limit Remaining at stop: " + twitterCtx.RateLimitRemaining.ToString());
            }
