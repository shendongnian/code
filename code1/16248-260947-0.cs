            int startIndex = 0;
            Action action = null;
            action = () =>
            {   // only processes a batch of 50 rows, then calls BeginInvoke
                // to schedule the next batch
                int endIndex = startIndex + 50;
                if (endIndex > dgItemMaster.Rows.Count) endIndex = dgItemMaster.Rows.Count;
                if (startIndex > endIndex)
                {
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        // process row i
                    }
                    startIndex = endIndex;
                    this.BeginInvoke(action); // next iteration
                }                
            };
            // kick it off
            this.BeginInvoke(action);
