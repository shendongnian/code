    var queue = new ConcurrentQueue<downloadItem>(downloadList);
    for (int i = 0; i < Math.Min(maxDownloads, queue.Count))
    {
      var thread = new Thread(
        () =>
        {
          while (true)
          {
            downloadItem item = null;
            if (queue.TryDequeue(out item))
            {
              // Process the next work item.
              DownloadItem(item);
            }
            else
            {
              // No more work items are left.
              break;
            }
          }
        });
        thread.IsBackground = true;
        thread.Start();
    }
