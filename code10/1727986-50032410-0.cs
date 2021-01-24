    using (var myContext = new DbContext())
            {
                using (var transaction = myContext.Database.BeginTransaction())
                {
                    try
                    {
                        var newCar = new Car();
                        myContext.Cars.Add(newCar);
                        myContext.SaveChanges();
    
                        var newBook = new Book();
                        newBook.Number = newCar.Id;
    
                        myContext.Books.Add(newBook);
                        myContext.SaveChanges();
    
                        // Commit transaction if all commands succeed, transaction will auto-rollback
                        // when disposed if either commands fails
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        // TODO: Handle failure
                    }
                }
            }
