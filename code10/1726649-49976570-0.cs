    private IEnumerable<string> FindVacanciesOnPage()
    {
        return FindVacanciesOnPage(new List<string>(), 0, 50, 15000);
    }
    private IEnumerable<string> FindVacanciesOnPage(ICollection<string> foundVacancies, long waitedTime, int interval, long maxWaitTime)
    {
        try
        {
            var list = Driver.FindElements(By.XPath("//*[@data-ng-bind=\"item.JobHeadline\"]"));
            foreach (var vacancy in list)
            {
                foundVacancies.Add(vacancy.Text);
            }
        }
        catch (Exception)
        {
            if (waitedTime >= maxWaitTime) throw;
    
            Thread.Sleep(interval);
            waitedTime += interval;
    
            return FindVacanciesOnPage(foundVacancies, waitedTime, interval, maxWaitTime);
    
        }
    
        return foundVacancies;
    }
