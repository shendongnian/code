        /// <remarks>
        ///     linq has optimistic concurrency, so objects can be changed by other users, while
        ///     submitted keep database changes but make sure users changes are also submitted
        ///     and refreshed with the changes already made by other users.
        /// </remarks>
        /// <returns>return if a refresh is needed.</returns>
        public bool SubmitKeepChanges()
        {
            // try to submit changes to the database.
            bool refresh = false;
            try
            {
                base.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            /* 
             * assume a "row not found or changed" exception, if thats the case:
             * - keep the database changes already made by other users and make sure
             * - this users changes are also written to the database
             */
            catch (ChangeConflictException)
            {
                // show where the conflicts are in debug mode
                ShowConflicts();
                // get database values and combine with user changes 
                base.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges);
                // submit those combined changes again to the database.
                base.SubmitChanges();
                // a refresh is needed
                refresh = true;
            }
            // return if a refresh is needed.
            return refresh;
        }
