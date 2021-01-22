    public List<string> ExpandLinksOrSomething(List<string> urls)
    {
        List<string> result = new List<string>();
        Queue<string> queue = new Queue<string>(urls);
        while (queue.Any())
        {
            string url = queue.Dequeue();
            result.Add(url);
            foreach( string newResult in GetLinks(url) )
            {
                queue.Enqueue(newResult);
            }
        }
        return result;
    }
