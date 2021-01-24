    public class User 
    {
            private readonly Lazy<Task<List<ReminderDb>>> _reminders;
    
            public SmsUserDb()
            {
                // Get _reminderReader from IoC
    
                _reminders = new Lazy<Task<List<ReminderDb>>>(async () => (List<ReminderDb>)await _reminderReader.Get(UserId));
            }
    
            public string UserId { get; set; }
            public Task<List<ReminderDb>> Reminders => _reminders.Value;
    }
