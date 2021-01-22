        /// <summary>
        /// dump changes in the context to the debug log
        /// <para>Debug logging must be turned on using log4net</para>
        /// </summary>
        /// <param name="context">The context to dump the changes for</param>
        public static void DumpChanges(this ObjectContext context)
        {
            context.DetectChanges();
            // Output any added entries
            foreach (var added in context.ObjectStateManager.GetObjectStateEntries(EntityState.Added))
            {
                Log.DebugFormat("{0}:{1} {2} {3}", added.State, added.Entity.GetType().FullName, added.Entity.ToString(), string.Join(",", added.CurrentValues.GetValue(1), added.CurrentValues.GetValue(2)));
            }
            foreach (var modified in context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified))
            {
                // Put original field values into dictionary
                var originalValues = new Dictionary<string,int>();
                for (var i = 0; i < modified.OriginalValues.FieldCount; ++i)
                {
                    originalValues.Add(modified.OriginalValues.GetName(i), i);
                }
                // Output each of the changed properties.
                foreach (var entry in modified.GetModifiedProperties())
                {
                    var originalIdx = originalValues[entry];
                    Log.DebugFormat("{6} = {0}.{4} [{7}][{2}] [{1}] --> [{3}]  Rel:{5}", 
                        modified.Entity.GetType(), 
                        modified.OriginalValues.GetValue(originalIdx), 
                        modified.OriginalValues.GetFieldType(originalIdx), 
                        modified.CurrentValues.GetValue(originalIdx), 
                        modified.OriginalValues.GetName(originalIdx), 
                        modified.IsRelationship, 
                        modified.State, 
                        string.Join(",", modified.EntityKey.EntityKeyValues.Select(v => string.Join(" = ", v.Key, v.Value))));
                }
            }
            // Output any deleted entries
            foreach (var deleted in context.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted))
            {
                Log.DebugFormat("{1} {0} {2}", deleted.Entity.GetType().FullName, deleted.State, string.Join(",", deleted.CurrentValues.GetValue(1), deleted.CurrentValues.GetValue(2)));
            }
        }
