    var ultraGridBand = this.ExperimentGrid.DisplayLayout.Bands[0];
                int nbGroup = ultraGridBand.Columns.All.Count(obj => ((UltraGridColumn) obj).IsGroupByColumn);
                //if (ultraGridBand.Columns.All.Any(obj => ((UltraGridColumn)obj).SortIndicator != SortIndicator.None)))
                if (nbGroup == 0)//no grouping
                    ultraGridBand.SortedColumns.RefreshSort(true);
                else if (nbGroup > 0)
                {
                    var expandedRows = new List<ExpandedRow>();
                    var rowLevel1 = this.ExperimentGrid.DisplayLayout.Rows;
                    ExtractExpandedRows(expandedRows, rowLevel1);
                    ultraGridBand.SortedColumns.RefreshSort(true);
                    SetExpandedRows(expandedRows, rowLevel1);
                }
    
        private static void SetExpandedRows(IEnumerable<ExpandedRow> expandedRows, RowsCollection rowLevel)
        {
            foreach (object obj in rowLevel.All)
            {
                var row = obj as UltraGridGroupByRow;
                if (row != null)
                {
                    var expandedRow = expandedRows.FirstOrDefault(x => x.Value == row.ValueAsDisplayText);
                    if (expandedRow != null)
                    {
                        row.Expanded = expandedRow.IsExpanded;
                        SetExpandedRows(expandedRow.SubRows, row.Rows);
                    }
                }
            }
        }
        private static void ExtractExpandedRows(ICollection<ExpandedRow> expandedRows, RowsCollection rowLevel)
        {
            foreach (object obj in rowLevel.All)
            {
                var row = obj as UltraGridGroupByRow;
                if(row != null)
                {
                    var expandedRow = new ExpandedRow() { Value = row.ValueAsDisplayText, IsExpanded = row.Expanded };
                    expandedRows.Add(expandedRow);
                    ExtractExpandedRows(expandedRow.SubRows, row.Rows);
                }
            }
        }
