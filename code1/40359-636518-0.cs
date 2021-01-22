        /// <summary>
        /// Summary: 
        ///     Does stuff.
        /// Exceptions:
        ///     ArgumentNullException:
        ///        args must be non-null
        /// </summary>
        /// <param name="args"></param>
        public static void DoStuff(string[] args)
        {
            if(args == null)
            throw new ArgumentNullException("args", "'args' parameter cannot be null.");
            ...
        }
