            int len = events.Count;
            if (len <= MAX_EVENTS_NO)
            {
                WaitHandle.WaitAll(events.ToArray());
            }
            else
            {
                int start = 0;
                int num = MAX_EVENTS_NO;
                while (true)
                {
                    if(start + num > len)
                    {
                        num = len - start;
                    }
                    List<ManualResetEvent> sublist = events.GetRange(start, num);
                    WaitHandle.WaitAll(sublist.ToArray());
                    start += num;
                    if (start >= len)
                        break;
                }
            }
