        public override void SubmitChanges(
            System.Data.Linq.ConflictMode failureMode)
        {
            ChangeSet changes = this.GetChangeSet();
            var recipeInserts = (from r in changes.Inserts
                           where (r as Recipe) != null
                           select r as Recipe).ToList<Recipe>();
            var recipeUpdates = (from r in changes.Updates
                           where (r as Recipe) != null
                           select r as Recipe).ToList<Recipe>();
            ConvertTextData(recipeInserts);
            ConvertTextData(recipeUpdates);
            base.SubmitChanges(failureMode);
        }
