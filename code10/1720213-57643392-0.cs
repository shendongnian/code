            object lockObj = new object();
            for (int i = 0; i < callCount; i++)
            {
                int j = i; // because of scope we can't use "i"  
                yield return Task.Run(async delegate {
                    var pair = await StringService.RandomValues.GetRandomStringWDelayAsync(j);
                    if (pair.Value != null)
                    {
                        lock (lockObj)
                            dictionary[j] = pair.Value;
                    }
                });
            }
