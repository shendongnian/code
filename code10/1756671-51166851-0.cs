    public virtual async Task<bool> GetData()
            {
                TaskCompletionSource<bool> ts = new TaskCompletionSource<bool>();
                if (order != null)
                {
                    //do something
                    ts.SetResult(true);
                }
                else
                {
                    // do something else
                    ts.SetResult(false);
                }
                return await ts.Task;
            }
