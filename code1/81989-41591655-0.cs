    public class FunctionReturnType
    {
        public Guid Id { get; set; } 
        
        public Guid AnchorId { get; set; } //the zeroPoint for the recursion
        // Add other fields as you want (add them to your tablevalued function also). 
        // I noticed that nextParentId and depth are useful
    }
    public class _YourDatabaseContextName_ : DbContext
    {
        [TableValuedFunction("RecursiveQueryFunction", "_YourDatabaseContextName_")]
        public IQueryable<FunctionReturnType> RecursiveQueryFunction(
            [Parameter(DbType = "boolean")] bool param1 = true
        )
        {
            //Example how to add parameters to your function
            //TODO: Ask how to make recursive queries with SQL 
            var param1 = new ObjectParameter("param1", param1);
            return this.ObjectContext().CreateQuery<FunctionReturnType>(
                $"RecursiveQueryFunction(@{nameof(param1)})", param1);
        }
            
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //add both (Function returntype and the actual function) to your modelbuilder. 
            modelBuilder.ComplexType<FunctionReturnType>();
            modelBuilder.AddFunctions(typeof(_YourDatabaseContextName_), false);
            base.OnModelCreating(modelBuilder);
        }
        public IEnumerable<Category> GetParents(Guid id)
        {
            //this = dbContext
            return from hierarchyRow in this.RecursiveQueryFunction(true)
                join yourClass from this.Set<YourClassThatHasHierarchy>()
                on hierarchyRow.Id equals yourClass.Id
                where hierarchyRow.AnchorId == id
                select yourClass;
        }
    }
