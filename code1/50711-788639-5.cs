    public static string ConcatenateWithTpl(IEnumerable<string> sequence)
    {
        var queue = new ConcurrentQueue<string>();
        bool stop = false;
        var consumer = Future.Create(
            () =>
                {
                    var sb = new StringBuilder("{");
                    while (!stop || queue.Count > 2)
                    {
                        string s;
                        if (queue.Count > 2 && queue.TryDequeue(out s))
                            sb.AppendFormat("{0}, ", s);
                    }
                    return sb;
                });
        // Producer
        foreach (var item in sequence)
            queue.Enqueue(item);
        stop = true;
        StringBuilder result = consumer.Value;
        string a;
        string b;
        if (queue.TryDequeue(out a))
            if (queue.TryDequeue(out b))
                result.AppendFormat("{0} and {1}", a, b);
            else
                result.Append(a);
        result.Append("}");
        return result.ToString();
    }
