        /// <summary>
        /// Detaches all of the DbEntityEntry objects that have been added to the ChangeTracker.
        /// </summary>
        public void DetachAll() {
            foreach (DbEntityEntry dbEntityEntry in this.Context.ChangeTracker.Entries()) {
                if (dbEntityEntry.Entity != null) {
                    dbEntityEntry.State = EntityState.Detached;
                }
            }
        }
