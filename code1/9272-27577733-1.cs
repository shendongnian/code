    for (int i = 0; i < TotalFile; i++)
    {
        Contact.Clear();
        if (innerloop == SplitSize)
        {
            for (int j = 0; j < SplitSize; j++)
            {
                string strContact = DSt.Tables[0].Rows[i * SplitSize + j][0].ToString();
                Contact.Add(strContact);
            }
            string strExcel = strFileName + "_" + i.ToString() + ".xlsx";
                             File.WriteAllLines(strExcel, Contact.ToArray());
        }
    }
