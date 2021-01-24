    public class CustomerEntity : TableEntity
            {
                public CustomerEntity(string lastName, string firstName)
                {
                    this.PartitionKey = lastName;
                    this.RowKey = firstName;
                }
    
                public CustomerEntity() { }
    
                public int? Order { get; set; }
                public string StartDate { get; set; }
                public string EndDate { get; set; }
                public string Text { get; set; }
    
                public DateTime? ConvertTime(string dateStr)
                {
                    if (string.IsNullOrEmpty(dateStr))
                        return null;
                    DateTime dt;
                    var convert=DateTime.TryParse(dateStr, out dt);
                    return dt;
                }
            }
