    //
    // Check if composite primary keys existe in database
    //
    StringBuilder strSelect = "SELECT * FROM " + _strTableName + " WHERE ";
    for (int i = 0; i < strCompositeKeyField.Length; i++)
    {
        bool boolKeyProcess = false;
        strSelect.AppendFormat("{0} =", 
            _strHeaderLineSplitedArray[(int)arrayListCompositeKeyIndex[i]]);
        DataColumn thisColomn = 
            _dsProcessDataFromFileAndPutInDataSetDataSet
            .Tables["Repartition"]
            .Columns[_strHeaderLineSplitedArray[(int)arrayListCompositeKeyIndex[i]]];
        //_strProcessDataFromFileAndPutInDataSetLog += "Debug: Composite key : " + _strHeaderLineSplitedArray[(int)arrayListCompositeKeyIndex[i]] + " dataType : " + thisColomn.DataType.ToString() + " arrayListCompositeKeyIndex[i] = " + arrayListCompositeKeyIndex[i] + " \n";
        // check if field is datetime to make convertion
        if (thisColomn.DataType.ToString() == "System.DateTime")
        {
            DateTime thisDateTime = 
                DateTime.ParseExact(strReadDataLineSplited[(int)arrayListCompositeKeyIndex[i]], 
               _strDateConvertion, null);
            strSelect.AppendFormat("'{0}'", thisDateTime.ToString());
            boolKeyProcess = true;
        }
        // check if field a string to add ''
        else if (thisColomn.DataType.ToString() == "System.String")
        {
            strSelect.AppendFormat("'{0}'", 
                strReadDataLineSplited[(int)arrayListCompositeKeyIndex[i]]);
            boolKeyProcess = true;
        }
        // check if field need hour to second converstion
        else
        {
            for (int j = 0; j < strHourToSecondConverstionField.Length; j++)
            {
                if (strCompositeKeyField[i] == strHourToSecondConverstionField[j])
                {
                    DateTime thisDateTime = DateTime.ParseExact(
                        strReadDataLineSplited[(int)arrayListCompositeKeyIndex[i]],
                        _strHourConvertion, 
                        System.Globalization.CultureInfo.CurrentCulture);
                    strSelect.Append(thisDateTime.TimeOfDay.TotalSeconds.ToString());
                    boolKeyProcess = true;
                }
            }
        }
        // if not allready process process as normal
        if (!boolKeyProcess)
        {
            strSelect.Append(strReadDataLineSplited[(int)arrayListCompositeKeyIndex[i]]);
        }
        // Add " AND " if not last field
        if (i != strCompositeKeyField.Length - 1)
        {
            strSelect.Append(" AND ");
        }
    }
    //_strProcessDataFromFileAndPutInDataSetLog += "Debug: SELECT = " + strSelect + "\n";
    SqlDataAdapter AdapterCheckCompositePrimaryKeys = new SqlDataAdapter(strSelect.ToString(), _scProcessDataFrinFileAndPutInDataSetSqlConnection);
    DataSet DataSetCheckCompositePrimaryKeys = new DataSet();
    AdapterCheckCompositePrimaryKeys.Fill(DataSetCheckCompositePrimaryKeys, "PrimaryKey");
