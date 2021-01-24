       private T Execute<T>(Func<MyModelContext, T> function)
            {
                using (MyModelContext ctx = new MyModelContext())
                {
                    var result = function(ctx);
                    ctx.SaveChanges();
                    return result;
                }
            }
      public List<Type> GetTypes()
            {
                return Execute((ctx) =>
                {
                    return ctx.Types.ToList();
                });
            }
