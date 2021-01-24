        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetCalendar()
        {
            string IcsFileData = EventsManager.GenerateCalendarString();
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(IcsFileData)
            };
            result.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("inline")
                {
                    FileName = "Calendar.ics"
                };
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("text/calendar");
            return result;
        }
