            public static Deque<DateClose> MAMethod(Queue<DateClose> queue,
            Deque<DateClose> firstMASample, int period)
        {
            Deque<DateClose> sample = new Deque<DateClose>(firstMASample.ToArray());
            Deque<DateClose> movingAverageQueue = new Deque<DateClose>(queue.Count() + 1);
            // get the last item or initial MA value from the queue
            DateClose mA = sample.RemoveFromBack();
            //DateClose dateClose = null;
            decimal sub = 0;
            DateClose add = null;
            //put the initial Ma value on the movingAverageQueue
            movingAverageQueue.AddToBack(mA);
            foreach (DateClose d in queue.ToList())
            {
                // create a new object for add subtraction moving averages           
                DateClose dateClose = new DateClose(sample.RemoveFromFront());
                sub = dateClose.Close;
                // create a new object to place the new moving average on the queue
                DateClose mAQueueValue = new DateClose(movingAverageQueue.Last());
                // subtract previous closing from new current MA
                mAQueueValue.Close = mAQueueValue.Close - sub/period;
                // add the new closing to new current MA
                add = d;
                sample.AddToBack(d);
                mAQueueValue.Close = mAQueueValue.Close + add.Close/period;
                mAQueueValue.Date = add.Date;
                movingAverageQueue.AddToBack(mAQueueValue);
                queue.Dequeue();
            }
            return movingAverageQueue;
        }
