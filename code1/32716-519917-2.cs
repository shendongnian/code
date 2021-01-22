    static IEnumerable<T> GetItems<T>(IEnumerable<Queue<T>> queues)
    {
        int remaining = queues.Sum(q => q.Count);
        Random rand = new Random();
        while (remaining > 0)
        {
            int index = rand.Next(remaining);
            foreach (Queue<T> q in queues)
            {
                if (index < q.Count)
                {
                    yield return q.Dequeue();
                    remaining--;
                    break;
                }
                else
                {
                    index -= q.Count;
                }
            }
        }
    }
