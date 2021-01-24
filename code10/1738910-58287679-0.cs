public CustomerNoAttribute : Attribute {
}
public class CustomerNoConvention : Convention
{
    public CustomerNoConvention()
    {
        this.Properties()
            .Where(p => p.GetCustomAttributes(false).OfType<CustomerNoAttribute>().Any()
            .Configure(c => c.HasColumnType("nvarchar")
                             .HasMaxLength(15)
                       );
    }
}
Now to use the custom attribute in your class:
[Table("foo")]
public class foo {
   …
    [CustomerNo]
    [Display(Name="Customer Identifier")]
    public string CustomerNo {get; set;}
   …
}
[Table("bar")]
public class bar {
   …
    [CustomerNo]
    [Display(Name="Customer Identifier")]
    public string CustomerNo {get; set;}
   …
}
Finally, we have to enable the custom convention, we can do this by overriding `OnModelCreating` in your `DbContext` class:
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Add(new CustomerNoConvention());
    }
An alternate solution to reducing the duplicate entries of multiple attributes and conventions is of course to use inheritance:
public abstract class HasCustomerNo {
   …
    [CustomerNo]
    [Display(Name="Customer Identifier")]
    public string CustomerNo {get; set;}
   …
}
[Table("foo")]
public class foo : HasCustomerNo  {
   …
    // no need for CustomerNo 
   …
}
[Table("bar")]
public class bar : HasCustomerNo {
   …
    // no need for CustomerNo 
   …
}
  [1]: https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/conventions/custom
