        /// <summary>
        /// This method should be used as a last resort...
        /// </summary>
        /// <param name="vinNumber"></param>
        /// <returns></returns>
        public int GetPrice(string vinNumber)
        {
            ...
        }
        /// <summary>
        /// This is the preferred method...
        /// </summary>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public int GetPrice(string make, string model, int year)
        {
            ...
        }
