            var dataTable = new DataTable();
            dataTable.Columns.Add("Col1", list1.GetType().GetGenericArguments().First());
            dataTable.Columns.Add("Col2", list2.GetType().GetGenericArguments().First());
            dataTable.Columns.Add("Col3", list3.GetType().GetGenericArguments().First());
            dataTable.Columns.Add("Col4", list4.GetType().GetGenericArguments().First());
            // assumes they all match on count
            for (int i = 0; i < list1.Count; i++)
            {
                dataTable.Rows.Add(list1[i], 
                                   list2[i],
                                   list3[i],
                                   list4[i]);
            }
