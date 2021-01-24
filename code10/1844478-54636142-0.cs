using (var context = new MovieContext())
{
    context.Movies.AddOrUpdate(m => m.Name, movie1);
    context.SaveChanges();
}
