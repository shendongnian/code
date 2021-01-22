        DateTime start = DateTime.Now;
        foreach (byte b in file.bytes)
        {
            if ((DateTime.Now - start).TotalMilliseconds >= 200)
            {
                UpdateCurrentFileStatus(current, total);
                start = DateTime.Now;
            }
        }
