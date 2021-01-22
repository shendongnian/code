    class Program
    {
        static void Main(string[] args)
        {
            List<Ticket> tickets = new List<Ticket>();
        tickets.Add(new Ticket() { CreateDate = DateTime.Now, Id = 1});
        tickets.Add(new Ticket() { CreateDate = DateTime.Now.AddDays(1), Id = 2 });
        tickets.Add(new Ticket() { CreateDate = DateTime.Now.AddDays(1), Id = 3 });
        tickets.Add(new Ticket() { CreateDate = DateTime.Now.AddDays(2), Id = 4 });
        tickets.Add(new Ticket() { CreateDate = DateTime.Now.AddDays(2), Id = 5 });
        tickets.Add(new Ticket() { CreateDate = DateTime.Now.AddDays(3), Id = 6 });
        tickets.Add(new Ticket() { CreateDate = DateTime.Now.AddDays(3), Id = 7 });
        tickets.Add(new Ticket() { CreateDate = DateTime.Now.AddDays(4), Id = 8 });
        tickets.Add(new Ticket() { CreateDate = DateTime.Now.AddDays(5), Id = 9 });
        tickets.Add(new Ticket() { CreateDate = DateTime.Now.AddDays(6), Id = 10 });
        tickets.Add(new Ticket() { CreateDate = DateTime.Now.AddDays(7), Id = 11 });
        var query = tickets.
                    GroupBy(t => t.CreateDate.Date).
                    Select(g => new { Date = g.Key, Count = g.Count() });
        foreach (var g in query)
        {
            Console.WriteLine("{0} - {1}", g.Date, g.Count);
        }
        /* Outputs:
           7/24/2010 12:00:00 AM - 1
           7/25/2010 12:00:00 AM - 2
           7/26/2010 12:00:00 AM - 2
           7/27/2010 12:00:00 AM - 2
           7/28/2010 12:00:00 AM - 1
           7/29/2010 12:00:00 AM - 1
           7/30/2010 12:00:00 AM - 1
           7/31/2010 12:00:00 AM - 1 */
    }
    class Ticket
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
