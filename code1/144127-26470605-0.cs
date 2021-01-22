    public class BaseEntity
    {
        public int Id { get; set; }
        public BaseEntity()
        {
            var stringProperties = this.GetType().GetProperties().Where(x => x.PropertyType == typeof(string));
            foreach (var property in stringProperties)
            {
                if (property.GetValue(this, null) == null)
                {
                    property.SetValue(this, string.Empty, null);
                }
            }
        }
    }
