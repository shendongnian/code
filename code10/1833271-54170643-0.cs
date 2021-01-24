    internal sealed class Configuration : DbMigrationsConfiguration<BookService.Models.BookServiceContext>
    {
         protected override void Seed(BookService.Models.BookServiceContext context)
         {
            Status status0 = new Status("WH-RAMP");
            Status status1 = new Status("Transport> Lijn");
            Status status2 = new Status("In lijn");
            Status status3 = new Status("Retour lijn");
            Status status4 = new Status("Transport > WH");
            context.Statuses.Add(status0);
            context.Statuses.Add(status1);
            context.Statuses.Add(status2);
            context.Statuses.Add(status3);
            context.Statuses.Add(status4);
         }
    }
