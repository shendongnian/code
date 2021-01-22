    class Thing {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public override string ToString() {
            return new ToStringBuilder<Thing>(this)
                .Append(t => t.Id)
                .Append(t => t.Name)
                .ToString()
        }
    }
    
    void Main() {
        var t = new Thing { Id = 10, Name = "Bob" };
        Console.WriteLine(t.ToString());
    }
