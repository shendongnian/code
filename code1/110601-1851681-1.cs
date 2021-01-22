            var result = userLogin.UserLoginClientConnectionHistories
                .GroupBy(y => new { Id = y.UserLoginHistoryID, Day = y.CreatedAt.Date })
                .Select(x => new
                {
                    Id = x.Key.Id,
                    Day = x.Key.Day,
                    MostRecent = x.Max(y => y.CreatedAt)
                });
