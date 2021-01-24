private void EnsureBaseState()
{
   _context.Database.EnsureDeleted();
   _context.SaveChanges();
}
private void EnsureSecondState()
{
   EnsureBaseState();
   _context.ExampleItems.Add(new ExampleItem { Id = 1, Name = "sample item" });
   _context.SaveChanges();
}
This is how we are currently managing multiple states, with the additional states calling a base state in the middleware. 
