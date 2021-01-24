                model = await _context.People
                    .Where(x => x.RecipientId == recipientId && x.DateCreated > startDate && x.DateCreated < endDate)
                    .Select(x => new { DateGrouped = x.DateCreated.ToString("yyyy-MM-dd"), x.RecipientId, x.SubscriptionType })
                    .GroupBy(x => new { x.DateGrouped, x.RecipientId })
                    .Select(a => new StatsViewModel
                    {
                        DateStatsFormatted = a.Key.DateGrouped,
                        Subscribed = a.Count(c=>c.SubscriptionType == SubscriptionType.Suscribed),
                        Unsubscribed = a.Count(c=>c.SubscriptionType == SubscriptionType.Unsuscribed),
                        NoSet = a.Count(c=>c.SubscriptionType == SubscriptionType.NoSet)
                    }
                    )
                    .ToListAsync();
