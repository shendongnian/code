    class Record : IEquatable<Record>
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public bool Equals(Record r)
        {
            if (r == null) return false;
            return this.Name.Equals(r.Name) && this.Number.Equals(r.Number);
        }
    }
