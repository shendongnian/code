    private bool Write(string text)
    {
        var t;
        foreach (char c in text)
        {
            t = Task.Run(() => Console.AppendText(c.ToString());
            t.Wait(TimeSpan.FromMilliseconds(50));
        }
        t = Task.Run(() => Console.AppendText(Console.AppendText(Environment.NewLine));
        t.Wait(); // wait for completion.
        return true;
    }
