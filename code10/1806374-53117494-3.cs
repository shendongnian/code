    internal interface IScheduledTask
    {
        Task DoWorkAsync();
    }
    internal class MailTask : IScheduledTask
    {
        private readonly ApplicationDbContext _context;
        public MailTask(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DoWorkAsync()
        {
            var mail = new Mail 
                       { Date = DateTime.Now,
                         Note = "lala",
                         Tema = "lala",
                         Email = "lala" };
            _context.Add(mail);
            await _context.SaveChangesAsync();
        }
    }
