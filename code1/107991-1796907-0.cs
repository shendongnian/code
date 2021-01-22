     using System.Linq.Dynamic;
     ...
     var count = repository.Query<T>()
                           .Where( "@0 == @1", property.Name, value )
                           .Count();
