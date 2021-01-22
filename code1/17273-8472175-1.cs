    /** <summary>Fills the System.Windows.Forms.ComboBox object DataSource with a 
     * list of T objects.</summary>
     * <param name="values">The list of T objects.</param>
     * <param name="displayedValue">A function to apply to each element to get the 
     * display value.</param>
     */
    public static void FillDataSource<T>(this ComboBox comboBox, List<T> values,
        Func<T, String> displayedValue) {
        // Create dataTable
        DataTable data = new DataTable();
        data.Columns.Add("ValueMember", typeof(T));
        data.Columns.Add("DisplayMember");
        for (int i = 0; i < values.Count; i++) {
            // For each value/displayed value
            // Create new row with value & displayed value
            DataRow dr = data.NewRow();
            dr["ValueMember"] = values[i];
            dr["DisplayMember"] = displayedValue(values[i]) ?? "";
            // Add row to the dataTable
            data.Rows.Add(dr);
        }
        // Bind datasource to the comboBox
        comboBox.DataSource = data;
        comboBox.ValueMember = "ValueMember";
        comboBox.DisplayMember = "DisplayMember";
    }
