        static void Main()
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add("Repartition");
            DataColumn col;
            col = dt.Columns.Add("ID_USAGER", typeof(int));
            col = dt.Columns.Add("TestString", typeof(string));
            col = dt.Columns.Add("TestInt", typeof(int));
            col = dt.Columns.Add("TestDouble", typeof(double));
            string testData = "TestString;TestInt;TestDouble";
            testData += Environment.NewLine + "Test1;1;1.1";
            testData += Environment.NewLine + "Test2;2;2.2";
            Test(ds, new StringReader(testData));
        }
        public static void Test(DataSet thisDataSet, StringReader sr)
        {
            string[] strDataLines = sr.ReadLine().Split(';');
            string strReadDataLine;
            strReadDataLine = sr.ReadLine();
            while (strReadDataLine != null)
            {
                string[] strReadDataLineSplited = strReadDataLine.Split(';');
                DataRow thisRow = thisDataSet.Tables["Repartition"].NewRow();
                DataTable item = thisDataSet.Tables["Repartition"];
                for (int i = 0; i < strDataLines.Length; i++)
                {
                    string columnName = strDataLines[i];
                    //#1 Don't use this as Columns[i] may not be Columns[columnName]
                    //DataColumn thisColomn = thisDataSet.Tables["Repartition"].Columns[i];
                    DataColumn thisColomn = thisDataSet.Tables["Repartition"].Columns[columnName];
                    //#2 Assing to the results of the string converted to the correct type:
                    thisRow[strDataLines[i]] = System.Convert.ChangeType(strReadDataLineSplited[i], thisColomn.DataType);
                }
                thisRow["ID_USAGER"] = 1;
                thisDataSet.Tables["Repartition"].Rows.Add(thisRow);
                strReadDataLine = sr.ReadLine();
            }
        }
