    public class Catalog_ProductMetadata
    {
        [Field(FieldIndex.Tokenized, FieldStore.Yes, IsKey = true)]
        public object ProductId { get; set; }
        [Field(FieldIndex.Tokenized, FieldStore.Yes, IsDefault = true)]
        public object Name { get; set; }
        [Field(FieldIndex.Tokenized, FieldStore.Yes)]
        public object Description { get; set; }
        [Field(FieldIndex.Tokenized, FieldStore.Yes)]
        public object Breadcrumb { get; set; }
        [Field(FieldIndex.Tokenized, FieldStore.Yes)]
        public object Tab1Content { get; set; }
        [Field(FieldIndex.Tokenized, FieldStore.Yes)]
        public object Tab2Content { get; set; }
        [Field(FieldIndex.Tokenized, FieldStore.Yes)]
        public object Tab3Content { get; set; }
        [Field(FieldIndex.Tokenized, FieldStore.Yes)]
        public object Tab4Content { get; set; }
        [Field(FieldIndex.Tokenized, FieldStore.Yes)]
        public object Tab5Content { get; set; }
        [Field(FieldIndex.Tokenized, FieldStore.Yes)]
        public object Manufacturer { get; set; }
    }
