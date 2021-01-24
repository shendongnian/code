     public async Task<List<Note>> GetAssignedItemsAsync(ApplicationUser user)
        {
            var lists = await _context.Lists.Include(l => l.Notes).Where(x => x.OwnerId != user.Id).ToListAsync();
            var notesListe = new List<Note>();
            foreach (List l in lists)
            {
                foreach (Note n in l.Notes)
                {
                    if (n.OwnerId == user.Id)
                    {
                        notesListe.Add(n);
                    }
                }
            }
            return  notesListe;
        }
