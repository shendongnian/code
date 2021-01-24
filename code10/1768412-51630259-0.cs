    public class User 
    {
            private readonly Lazy<Task<List<ReminderDb>>> _reminders;
    
            public SmsUserDb()
            {
    			// Get _reminderReader from IoC
    		
                _reminders = new Lazy<Task<List<ReminderDb>>>(GetReminders);
            }
    
            public string UserId { get; set; }
            public Task<List<ReminderDb>> Reminders
            {
                get
                {
                    return _reminders.Value;
                }
            }
    		
    		private async Task<List<ReminderDb>> GetReminders()
            {
                return (List<ReminderDb>)await _reminderReader.Get(UserId);
            }
    }
