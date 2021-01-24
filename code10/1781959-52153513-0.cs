    public static class TaskExtensions
    {
        public static async Task<Unit> ToUnit(this Task task)
        {
            await task;
            return unit;
        }
    }
