    DateTime firstdate = DateTime.Parse(myReader.GetString("CINd"));
    DateTime seconddate = DateTime.Parse(myReader.GetString("COUTd"));
    string firstdatestring = firstdate.ToLongDateString();
    string seconddatestring = seconddate.ToLongDateString();
    string time1 = myReader.GetString("CINt");
    string time2 = myReader.GetString("COUTt");
    dbdate1.Text = firstdatestring + " " + time1;
    dbdate2.Text = seconddatestring + " " + time2;
