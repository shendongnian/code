    function IsConnValid(var Conn: TADOConnection; DBType: TDBType): boolean;
    var
      qry : TADOQuery;
    begin
      //gimme a connection, and i'll create a query, try to retrieve dummy data.
      //if retrieval works, return TRUE. otherwise, return FALSE.
      qry := TADOQuery.Create(nil);
      try
        qry.Connection := Conn;
    
        case DBType of
          //syntax for a dummy query varies by vendor.
          dbOracle    : qry.Sql.Add('SELECT 1 FROM DUAL');
          dbSqlServer : qry.Sql.Add('SELECT 1');
        end;  //case
    
        try
          qry.Open;
          //try to open the query.
          //if we lost the connection, we'll probably get an exception.
          Result := not(qry.Eof);  //a working connection will NOT have EOF.
          qry.Close;
        except on e : exception do
          //if exception when we try to open the qry, then connection went bye-bye.
          Result := False;
        end;  //try-except
      finally
        qry.Free;
      end;  //try-finally
    end;
