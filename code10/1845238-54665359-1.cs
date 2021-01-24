    OleDbConnection con = new OleDbConnection(Utility.GetConnectionString());
    OleDbCommand cmd = new OleDbCommand(@"SELECT A.AgencyName, T.TradeDate, T.InvoiceNo, T.TicketNo, T.PassengerName, T.FatherName, T.TicketAmount, T.RefundAmount 
                                        FROM Agencies AS A, Trade AS T 
                                        WHERE T.Account_ID=A.Account_ID 
                                        and T.TradeType = @TradeType And T.TradeDate >= @FromDate And T.TradeDate < @ToDate", con);
    cmd.CommandType = CommandType.Text;
    cmd.Parameters.Add("@TradeType", OleDbType.VarWChar).Value = TradeType;
    cmd.Parameters.Add("@FromDate", OleDbType.Date).Value = FromDate;
    cmd.Parameters.Add("@ToDate", OleDbType.Date).Value = ToDate;
