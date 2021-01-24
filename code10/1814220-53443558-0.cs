    string SQLQuery = "INSERT INTO TABLEABC VALUES(@RText, @TDate)";
    SQLCommand Command = new SQLCommand(SQLQuery, YourConnection);
    Command.Parameters.Add("@RText",SQLDbType.varchar);
    Command.Parameters["@RText"].Value = RText; //Assumed variable name
    Command.Parameters.Add("@TDate",SQLDbType.date); //Assumed datatype
    Command.Parameters["@TDate"].Value = TDate; //Assumed variable name
