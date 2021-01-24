     public class IdValueGenerator:ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => false;
        public override string Next(EntityEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            var context = (TodoDbContext)entry.Context;
            var id = context.TodoItem.LastOrDefault()?.Id == null ?
                    "A001"
                    : Regex.Replace(context.TodoItem.LastOrDefault()?.Id, "\\d+", m => (int.Parse(m.Value) + 1).ToString(new string('0', m.Value.Length)));
          
            return id;
        }
    }
