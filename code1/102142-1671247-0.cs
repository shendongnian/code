try
{
    ... stuff happens here...
}
catch (Exception ex1)
{
    lock(queue)
    {
        queue.Enqueue(ex1);
        Monitor.PulseAll(queue);
    }
}
