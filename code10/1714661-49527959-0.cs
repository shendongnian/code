    public class Customer : Entity
    {
    }
    
    public class Supplier : Entity
    {
    }
    
    public void CreateEntity(string TableName, Entity entity)
    {
    	using(var context = new MyDbContext())
    	{
    		var name = new SqlParameter("@name", entity.customerName);
    		var age = new SqlParameter("@age", entity.customerAge);	
    		context.Database.ExecuteSqlCommand($"insert into {TableName} (customerName, customerAge) values (@name, @age)", 
                 name, age);
    	}
    }
