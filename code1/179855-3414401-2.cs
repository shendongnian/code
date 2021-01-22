        /// </summary>
        /// <returns></returns>
        public DataTable CombineDatatable(ref DataTable destini, DataTable source)
        {
            foreach (DataRow dr in source.Rows)
            {
                destini.ImportRow(dr);
            }
            return destini;
        }
        #endregion  
