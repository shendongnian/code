    public class CleanExpiredJob : IJob
    {
        // Your ConcurrentDictionary value will be injected by the scheduler
        public ConcurrentDictionary<TKey, TValue> Items {private get; set;}
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() => {
                foreach (var item in Items)
                {
                    var guid = item.Key;
                    var customItem = item.Value;
                    if (customItem.ConditionToRemoveItemFromDictionaryHere)
                    {
                        var removeItem = Items.TryRemove(guid, out _);
                        // ...
                    }
                }
            });
        }
    }
