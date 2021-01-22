        private DateTime GetNextRun()
        {
            var today = DateTime.Today;
            var runTime = new DateTime(today.Year, today.Month, today.Day, 17, 0, 0);
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var offset = timeZoneInfo.GetUtcOffset(runTime);
            var dto = new DateTimeOffset(runTime, offset);
            if (DateTime.Now > dto.LocalDateTime) 
                dto = dto.AddDays(1);
            return dto.LocalDateTime;
        }
