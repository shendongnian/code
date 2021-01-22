    Queue<TimeSpan> allTimeSpans = GetQueueOfTimeSpans();
    Queue<TimeSpan> averages = New Queue<TimeSpan>(50);
    int partitionSize = 10;
    for (int i = 0; i <50; i++) {
        var avg = allTimeSpans.Skip(i * partitionSize).Take(partitionSize).Average(t => t.Ticks)
        averages.Enqueue(new TimeSpan(avg));
    }
