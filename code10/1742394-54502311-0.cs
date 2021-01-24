    public List<string> GetContexts()
        {
            List<string> AllContexts= new List<string>();
            foreach (var context in (driver.Contexts))
            {
                AllContexts.Add(context);
            }
            return AllContexts;
        }
