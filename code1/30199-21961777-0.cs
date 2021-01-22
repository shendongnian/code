            public void ClearFrame(ulong timeStamp)
        {
            if (RecordSet.Count <= 0) return;
            if (Limit == false)
            {
                var seconds = (timeStamp - RecordSet[0].TimeStamp)/1000;
                if (seconds <= _preFramesTime) return;
                Limit = true;
                do
                {
                    RecordSet.Remove(RecordSet[0]);
                } while (((timeStamp - RecordSet[0].TimeStamp) / 1000) > _preFramesTime);
            }
            else
            {
                RecordSet.Remove(RecordSet[0]);
                
            }
            GC.Collect(); // AVOID
        }
