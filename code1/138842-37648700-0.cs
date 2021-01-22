            /// <summary>
            /// Detaches all of the EntityEntry objects that have been added to the ChangeTracker.
            /// </summary>
            public void DetachAll()
            {
                foreach (EntityEntry entityEntry in this.Context.ChangeTracker.Entries())
                {
                    if (entityEntry.Entity != null)
                    {
                        entityEntry.State = EntityState.Detached;
                    }
                }
            }
