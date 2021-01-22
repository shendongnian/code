            private static LatestScreeeningsModel GetLatestScreening(IPublishedContent currentNode)
        {
            LatestScreeeningsModel latestScreening = new LatestScreeeningsModel();
            DateTime fileDate;
            // get a list of screenings that have not shown yet
            var screenings = currentNode.AncestorsOrSelf("siteLanguage")
                                       .FirstOrDefault().Descendants("screening")
                                       .Select(x => new LatestScreeeningsModel() { Id = x.Id, Date = x.GetPropertyValue<DateTime>("date") })
                                       .Where(x => x.Date > DateTime.Now).ToList();
            fileDate = DateTime.Today;
            long min = Math.Abs(fileDate.Ticks - screenings[0].Date.Ticks);
            long diff;
            foreach (var comingDate in screenings)
            {
                diff = Math.Abs(fileDate.Ticks - comingDate.Date.Ticks);
                if (diff <= min)
                {
                    min = diff;
                    latestScreening = comingDate;
                }
            }
            return latestScreening;
        }
