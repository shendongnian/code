    public class MyEntity : TableEntity
    {
        [IgnoreProperty]
        public decimal ListPrice
        {
            get => decimal.Parse(this.ListPrice_, CultureInfo.InvariantCulture);
            set => this.ListPrice_ = value.ToString(CultureInfo.InvariantCulture);
        }
        private string ListPrice_ { get; set; }
        public override void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            this.ListPrice_ = properties[nameof(ListPrice)].StringValue;
        }
        public override IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            var properties = new Dictionary<string, EntityProperty>();
            properties.Add(nameof(ListPrice), new EntityProperty(this.ListPrice_));
            return properties;
        }
    }
