        // Helper Functions
        private static List<T> RemoveDuplicates<T>(List<T> listWithDuplicates)
        {
            List<T> list = new List<T>();
            foreach (T row in listWithDuplicates)
            {
                if(!list.Contains(row))
                    list.Add(row);
            }
            return list;
        }
        private static List<DataRow> MatchingParents(DataTable table, string filter, string parentRelation)
        {
            List<DataRow> list = new List<DataRow>();
            DataView filteredView = new DataView(table);
            filteredView.RowFilter = filter;
            foreach (DataRow row in filteredView.Table.Rows)
            {
                list.Add(row.GetParentRow(parentRelation));
            }
            return list;
        }
        // Filtering Code
        List<DataRow> productRowsMatchingFeature = MatchingParents(productDS.Feature, 
                                                                       "Name = 'Width'",
                                                                       "FK_Product_Feature");
        List<DataRow> productRowsWithMatchingSupplier = MatchingParents(productDS.Supplier,
                                                                       "Name = 'Microsoft'",
                                                                       "FK_Product_Supplier");
        List<DataRow> matchesBoth = productRowsMatchingFeature.FindAll(productRowsWithMatchingSupplier.
                                                                               Contains);
        List<DataRow> matchingProducts = RemoveDuplicates(matchesBoth);
