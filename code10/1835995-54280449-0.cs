    static void Main()
        {
            var childA = new MyChild { Id = 0, FieldA = false, MyParentId = 0 };
            var parentA = new MyParent { Id = 0, Name = "John", Enabled = true };
            var childB = new MyChild { Id = 1, FieldA = true, MyParentId = 1 };
            var parentB = new MyParent { Id = 1, Name = "Jane", Enabled = true };
    
            var parents = new[] { parentA, parentB }.AsQueryable();
            var children = new[] { childA, childB }.AsQueryable();
    
            var userField = "FieldA";
    
            var childQuery = from child in children.Where(c => c.GetType().GetProperty(userField).GetValue(c).Equals(true)) select child;
    
            var query =
                from parent in parents
                join child in childQuery on parent.Id equals child.MyParentId
                where parent.Enabled
                select parent.Name;
        }
