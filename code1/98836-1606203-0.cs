    class ProfileSqlQueryExecutor : QueryExecutor<ProfileNodeCollection>
    {
        public override ProfileNodeCollection Execute()
        {
            ProfileNodeCollection nodes = new ProfileNodeCollection();
            // Logic to build nodes
            return nodes;
        }
    }
    
    class TreeSqlQueryExecutor : QueryExecutor<TreeNodeCollection>
    {
        public override TreeNodeCollection Execute()
        {
            TreeNodeCollection nodes = new TreeNodeCollection();
            Logic to build nodes
            return nodes;                
        }
    }
