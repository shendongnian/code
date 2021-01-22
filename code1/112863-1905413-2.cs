    namespace Com.StackOverflow {
    
        using System.Diagnostics;
        using System.Data;
        using System.Collections;
    
        public static class SOQuestion__Add_two_arraylists_in_a_datatable {
    
            public static void AnswerQuestionDirectly() {
    
                // - - - - - - - - Prelimary setup to question - - - - - - - -
    
                // Sample list of filenames (3 elements in total).
                ArrayList listFilenames = new ArrayList( new[] {@"C:\a.dat", @"C:\b.dat", @"C:\c.dat"} );
    
                // Sample list of error counts (2 elements in total).
                ArrayList listFailureCounts = new ArrayList( new[] {88,51} );
    
                // - - - - - - A Direct answer to the question - - - - - - -
    
                // Create DataTable structure with one column.
                DataTable dTable = new DataTable();
                dTable.Columns.Add("Column 1");
    
                /* Populate DataTable with all lists at once. 
                 * Note: keep appending 
                 * to { array initialization list } all lists you want included
                 * in the DataTable instance.
                 */
                foreach (ArrayList currentList in new[] { listFilenames, listFailureCounts }) {
                    foreach (object element in currentList)
                        dTable.Rows.Add(new[] { element }); // one column per row
                }
    
                // - - - - - - - - Test it for expected counts - - - - - - - -
    
                int totalExpected = listFilenames.Count + listFailureCounts.Count;
                //Verify DataTable contains the same amount of rows.
                Debug.Assert(dTable.Rows.Count == totalExpected);
            }
        }
    }
