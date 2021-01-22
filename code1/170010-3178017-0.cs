        /// <summary>
        /// Available only in derived classes
        /// </summary>
        public virtual void AFunctionToImplement2()
        {
            throw new ProtectedMethodException("Please do not call this method in the base class:) ");
        }
