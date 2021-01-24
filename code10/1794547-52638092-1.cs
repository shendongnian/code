    public class AViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class BViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<AViewModel> As { get; set; }
    }
    public IEnumerable<BViewModel> GetBs()
    {
       return _context.Bs.Include(b => b.myAs)
            .Select(b => new BViewModel
            {
                Id = b.Id,
                Name = b.Name,
                As = b.As.Select(a => new AViewModel
                {
                     Id = a.Id,
                     Name = a.Name
                })
            })
            .ToList();
    }
