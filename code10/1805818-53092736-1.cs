    for (int i = 0; i < n - 1; i++)
            {
                DataRow dr = table.NewRow();
                if(i==0)
                   {
                      dr[col1]="Data"
                      dr[col2]= ...
                      dr[col3]= ...
                      ...
                   }
                 if(i>0)
                   {
                      // your code
                   }
                table.Rows.Add(dr);
             }
