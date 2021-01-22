            if (Monitor.TryEnter(Processing, 1000))
            {
                try
                {
                    //do x
                }
                finally
                {
                    Monitor.Exit(Processing);
                }
            }
