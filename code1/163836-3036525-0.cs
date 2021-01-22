            for (int i = 0; i < listMyColumnNames.Count; ++i)
            {
                 Text += listMyColumnNames[i] + " nvarchar(500)";
                 if (i < listMyColumnNames.Count-1)
                     Text += ", ";
            }
