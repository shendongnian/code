            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);
            DateTime week = today.AddDays(-7); // or -6  think about it
            string userID = User.Identity.GetUserId();
            string email = (from x in db.Users where x.Id == userID select x.Email).FirstOrDefault();
            var valuesList = db.UsageDatas
                .Where(x => x.Time >= week && x.Time < tomorrow && x.UserEmail == email)
                //.AsEnumerable() //posible need it for execute sql before take DayOfWeek
                .GroupBy(x => x.Time.DayOfWeek)
                .Select(x => new
                {
                    DayOfWeek = x.Key,
                    Values = x.Select(m => m.Delta).Aggregate((a, b) => a + "," + b)
                })
                .OrderBy(m => m.DayOfWeek)
                .Select(x => new ValuesList
                {
                    Dates = x.DayOfWeek.ToString(),
                    Values = x.Values
                });
