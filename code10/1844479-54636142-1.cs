static void Main()
{
    Director directorA = new Director()
    {
        Name = "A"
    };
    using (var context = new MovieContext())
    {
        context.Directors.Add(directorA);
        context.SaveChanges(); // Here the object directorA will be updated with the right ID. So movie inserts wont create a new Director
    }
    Movie movie1 = new Movie()
    {
        Name = "foo",
        Director = directorA
    };
    Movie movie2 = new Movie()
    {
        Name = "bar",
        Director = directorA
    };
    using (var context = new MovieContext())
    {
        context.Movies.Add(movie1);
        context.SaveChanges();
    }
    using (var context = new MovieContext())
    {
        context.Movies.Add(movie2);
        context.SaveChanges();
    }
}  
<hr>
<strike>You can use the method AddOrUpdate. The first param is the field to check the uniqueness of. So if the name is found, that existing entry will be updated and if it doesn't exist, the new model will be inserted.
using (var context = new MovieContext())
{
    context.Movies.AddOrUpdate(m => m.Name, movie1);
    context.SaveChanges();
}
</strike>
