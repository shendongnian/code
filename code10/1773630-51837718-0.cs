    public void CompressData(TimeSpan compression)
        {
            //declare generic buffer value function (bid/ask here)
            var bufferFunction = new Func<int, double>(index => (Bid[index] + Ask[index]) / 2);
            
            Open = new List<double>();
            High = new List<double>();
            Low = new List<double>();
            Close = new List<double>();
            var lastCompTs = -1L;
            var dataBuffer = new List<double>();
            var timeStamps = new List<DateTime>();
            for (int i = 0; i < TimeStamps.Count; ++i)
            {
                var compTs = TimeStamps[i].Ticks / compression.Ticks;
                if (compTs == lastCompTs)
                {
                    //same timestamp -> add to buffer
                    dataBuffer.Add(bufferFunction(i));
                }
                else
                {
                    if (dataBuffer.Count > 0)
                    {
                        timeStamps.Add(new DateTime(compTs * compression.Ticks));
                        Open.Add(dataBuffer.First());
                        High.Add(dataBuffer.Max());
                        Low.Add(dataBuffer.Min());
                        Close.Add(dataBuffer.Last());
                    }
                    lastCompTs = compTs;
                    dataBuffer.Clear();
                }
            }
            if (dataBuffer.Count > 0)
            {
                timeStamps.Add(new DateTime(lastCompTs * compression.Ticks));
                Open.Add(dataBuffer.First());
                High.Add(dataBuffer.Max());
                Low.Add(dataBuffer.Min());
                Close.Add(dataBuffer.Last());
            }
            //assign time series collection
            TimeStamps = timeStamps;
        }
