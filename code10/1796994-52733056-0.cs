    /// <summary>
        /// Determines whether the specified entity key is attached is attached.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified context is attached; otherwise, <c>false</c>.
        /// </returns>
        internal static bool IsAttached(this ObjectContext context, EntityKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
    
            ObjectStateEntry entry;
            if (context.ObjectStateManager.TryGetObjectStateEntry(key, out entry))
            {
                return (entry.State != EntityState.Detached);
            }
            return false;
        }
