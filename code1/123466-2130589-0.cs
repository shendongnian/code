    var someDate = DateTime.Now.AddMonths(-1);
    var genInfo = ctx.TblGeneralInfos.Where(g => g.Date > someDate);
    
    //old-fashioned datatable seems to fit our needs well for storing the output data.
    var scratchTable = new DataTable();
    scratchTable.Columns.Add("RecordId");//repeat for any other fields in General Info we need to output
    
    //do one pass through data get the field names from random info and add each possibly column to scratch table
    foreach (var g in genInfo)
    {                
        foreach(var r in g.TblRandomInfos)
        {
            if(scratchTable.Columns.Contains(r.QuestionName)
            {
                scratchTable.Columns.Add(r.QuestionName);
            }
        }
    }
    
    //now that scratch table has every column we could need, read and populate from data
    foreach (var g in genInfo)
    {       
        var row = scratchTable.NewRow();
        row["RecordId"] = g.RecordId.ToString();
        foreach(var r in g.TblRandomInfos)
        {
            row[r.QuestionName] = r.Answer;
        }
        scratchTable.Rows.Add(row);// put row in scratch table
    }
    
    //Now all you have to do is convert datatable to csv... this is well documented online
    //  http://www.dotnetspark.com/kb/436-convert-datatable-to-csv-file-using-c-sharp.aspx
