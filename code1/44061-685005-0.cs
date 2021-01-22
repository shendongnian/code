        public static DataGridViewColumn GetFirstColumnWithAny(
            DataGridViewColumnCollection columns, // optional "this"
            DataGridViewElementStates states)
        {
            foreach (DataGridViewColumn column in columns)
            {
                if ((column.State & states) != 0) return column;
            }
            return null;
        }
