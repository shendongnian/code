        static async Task ListDirectMessagesAsync(TwitterContext twitterCtx)
        {
            int count = 50; // set to a low number to demo paging
            string cursor = "";
            List<DMEvent> allDmEvents = new List<DMEvent>();
            // you don't have a valid cursor until after the first query
            DirectMessageEvents dmResponse =
                await
                    (from dm in twitterCtx.DirectMessageEvents
                     where dm.Type == DirectMessageEventsType.List &&
                           dm.Count == count
                     select dm)
                    .SingleOrDefaultAsync();
            allDmEvents.AddRange(dmResponse.Value.DMEvents);
            cursor = dmResponse.Value.NextCursor;
            while (!string.IsNullOrWhiteSpace(cursor))
            {
                dmResponse =
                    await
                        (from dm in twitterCtx.DirectMessageEvents
                         where dm.Type == DirectMessageEventsType.List &&
                               dm.Count == count &&
                               dm.Cursor == cursor
                         select dm)
                        .SingleOrDefaultAsync();
                allDmEvents.AddRange(dmResponse.Value.DMEvents);
                cursor = dmResponse.Value.NextCursor;
            }
            if (!allDmEvents.Any())
            {
                Console.WriteLine("No items returned");
                return;
            }
            Console.WriteLine($"Response Count: {allDmEvents.Count}");
            Console.WriteLine("Responses:");
            allDmEvents.ForEach(evt =>
            {
                DirectMessageCreate msgCreate = evt.MessageCreate;
                if (evt != null && msgCreate != null)
                    Console.WriteLine(
                        $"DM ID: {evt.ID}\n" +
                        $"From ID: {msgCreate.SenderID ?? "None"}\n" +
                        $"To ID:  {msgCreate.Target?.RecipientID ?? "None"}\n" +
                        $"Message Text: {msgCreate.MessageData?.Text ?? "None"}");
            });
        }
