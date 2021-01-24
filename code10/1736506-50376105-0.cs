    public class NotesRepository
    {
        private readonly HDDbContext _context;
        public NotesRepository(HDDbContext context)
        {
            _context = context;
        }
    
        public Task<Note> GetNoteAsync(int id)
        {
            // your logic
            return note;
        }
    }
