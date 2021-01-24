    public async Task<bool> TryToConnect(bool firstTime, int second)
        {
            var valueToReturne = false;
            if (firstTime)
                await Task.Delay(1200);
            var ct = new CancellationTokenSource(TimeSpan.FromSeconds(second)).Token;
            var pingSender = new Ping();
            Task<PingReply> result;
            while (!ct.IsCancellationRequested)
            {
                result = pingSender.SendPingAsync("www.google.com", 100);//null exeption
                if (result.Status != TaskStatus.RanToCompletion)
                    continue;
                valueToReturne = true;
                break;
            }
            return valueToReturne;
        }
