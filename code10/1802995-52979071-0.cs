    public partial class NorthwindEntities
    {
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
     
                // Join the list to a single string.
                var fullErrorMessage = string.Join(&quot;; &quot;, errorMessages);
     
                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, &quot; The validation errors are: &quot;, fullErrorMessage);
     
                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
