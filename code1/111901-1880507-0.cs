    myConnection.InfoMessage += new SqlInfoMessageEventHandler(myConnection_InfoMessage);
    void myConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
        myStringBuilderDefinedAsClassVariable.AppendLine(e.Message);
    }
