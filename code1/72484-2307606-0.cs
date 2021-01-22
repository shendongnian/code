        /// <summary>
        /// Add a new row to our grid.
        /// </summary>
        /// The row should autosize to match whatever is placed within.
        /// <returns>Index of new row.</returns>
        public int AddAutoSizeRow()
        {
            Panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            Panel.RowCount = Panel.RowStyles.Count;
            mCurrentRow = Panel.RowCount - 1;
            return mCurrentRow;
        }
