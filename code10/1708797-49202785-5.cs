    public interface IAuditable
    {
        string InsertedBy { get; set; }
        // ... other properties
    }
    public class SomeEntity : IAuditable
    {
        public string InsertedBy { get; set; }
    }
    public class Auditor<TAuditable> where TAuditable : IAuditable
    {
        public void ApplyAudit(TAuditable entity, int userId)
        {
            // No reflection and you get compiler support
            if (entity.InsertedBy == null)
            {
                // whatever
            }
            else
            {
                // whatever
            }
        }
    }
