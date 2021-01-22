        /// <summary>
        /// Submits changes and, if there are any conflicts, the database changes are auto-merged for 
        /// members that client has not modified (client wins, but database changes are preserved if possible)
        /// </summary>
        public void SubmitKeepChanges()
        {
            this.Submit(RefreshMode.KeepChanges);
        }
        /// <summary>
        /// Submits changes and, if there are any conflicts, simply overwrites what is in the database (client wins).
        /// </summary>
        public void SubmitOverwriteDatabase()
        {
            this.Submit(RefreshMode.KeepCurrentValues);
        }
        /// <summary>
        /// Submits changes and, if there are any conflicts, all database values overwrite
        /// current values (client loses).
        /// </summary>
        public void SubmitUseDatabase()
        {
            this.Submit(RefreshMode.OverwriteCurrentValues);
        }
        /// <summary>
        /// Submits the changes using the specified refresh mode.
        /// </summary>
        /// <param name="refreshMode">The refresh mode.</param>
        private void Submit(RefreshMode refreshMode)
        {
            bool moreToSubmit = true;
            do
            {
                try
                {
                    this.SubmitChanges(ConflictMode.ContinueOnConflict);
                    moreToSubmit = false;
                }
                catch (ChangeConflictException)
                {
                    foreach (ObjectChangeConflict occ in this.ChangeConflicts)
                    {
                        occ.Resolve(refreshMode);
                    }
                }
            }
            while (moreToSubmit);
        }
