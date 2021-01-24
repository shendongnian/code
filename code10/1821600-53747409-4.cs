    DataTable dt10 = new DataTable();
    
    dt10.Columns.Add("UserId");
    dt10.Columns.Add("Nickname");
    dt10.Columns.Add("TimeShift");
    dt10.Columns.Add("MessageId");
    dt10.Columns.Add("MessageText");
    
    var query = from dtquer in dtmsgbody.AsEnumerable()
                join dtusr in dtbodyuser.AsEnumerable()
                on dtquer.Field<string>("userId") equals
                dtusr.Field<string>("userId")
    
                select new
                {
    
                    userId = dtquer.Field<string>("userId"),
                    userNick = dtusr.Field<string>("userNick"),
                    timeShift = dtquer.Field<int>("timeShift"),
                    message_Id = dtquer.Field<int>("message_Id"),
                    msgText_Text = dtquer.Field<string>("msgText_Text")
    
    
                 };
    
    var counter = 0;
    
    foreach (var row in query)
    {
         dt10.NewRow();
         var newRow = dt10.Rows[counter];
    
         newRow.ItemArray[0] = row.userId;
         newRow.ItemArray[1] = row.userNick;
         newRow.ItemArray[2] = row.timeShift;
         newRow.ItemArray[3] = row.message_Id;
         newRow.ItemArray[4] = row.msgText_Text;
    
         counter++;
     }
    
     // Should end up with dt10 having all the results from the query above loaded into it
