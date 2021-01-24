    public class ProductBusiness
    {
        ILogger logger;
        //...
        public void Create(Product p)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    db.Products.Add(p);
                    db.SaveChanges();
                    logger.Log($"Create Product - {DateTime.Now} - Id:{p.Id}, Name:{p.Name}");
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Error - {DateTime.Now} - {ex.ToString()}");
                throw;
            }
        }
        //...
    }
