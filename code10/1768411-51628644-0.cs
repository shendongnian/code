    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    namespace Demo
    {
        public class ReminderDb
        {
            public string Value;
        }
        public class ReminderReader
        {
            public async Task<List<ReminderDb>> Get(string userId)
            {
                Console.WriteLine("In Get() for " + userId);
                await Task.Delay(1000);
                Console.WriteLine("Returning from Get()");
                return new List<ReminderDb>{new ReminderDb{Value = userId}};
            }
        }
        public class Cache
        {
            public void Add(string key, SmsUserDb value)
            {
                _cache.Add(key, value);
            }
            public async Task<SmsUserDb> GetHashedAsync(string key)
            {
                await Task.Delay(1000);
                return _cache[key];
            }
            readonly Dictionary<string, SmsUserDb> _cache = new Dictionary<string, SmsUserDb>();
        }
        public class SmsUserDb
        {
            readonly Lazy<Task<List<ReminderDb>>> _reminders;
            readonly ReminderReader _reminderReader = new ReminderReader();
            public SmsUserDb()
            {
                _reminders = new Lazy<Task<List<ReminderDb>>>(async () => (List<ReminderDb>) await _reminderReader.Get(UserId));
            }
            public string                 UserId    { get; set; }
            public Task<List<ReminderDb>> Reminders => _reminders.Value;
        }
        static class Program
        {
            static async Task Main()
            {
                var db = new SmsUserDb(){UserId = "user ID"};
                var cache = new Cache();
                cache.Add("key", db);
                Console.WriteLine("Press RETURN to await cache.GetHashedAsync()");
                Console.ReadLine();
                var result = await cache.GetHashedAsync("key");
                Console.WriteLine("Press RETURN to await Reminders[0].Value");
                Console.ReadLine();
                Console.WriteLine((await result.Reminders)[0].Value);
            }
        }
    }
