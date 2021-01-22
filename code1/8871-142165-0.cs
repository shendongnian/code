     class ValidationRule<T> where T : Entity
     {
          private Func<T, bool> _rule;
          public ValidationRule(Func<T, bool> rule)
          {
               _rule = rule;
          }
          public bool IsValid(T entity)
          {
               return _rule(entity);
          }
     }
