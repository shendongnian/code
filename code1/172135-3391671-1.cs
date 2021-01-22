    procedure LoadCustomerFromQuery(var Query: TQuery; var Customer: TCustomer); stdcall;
    begin
    
      FillChar(Customer, SizeOf(Customer), 0);
    
      StrToBuf(Query.FieldByName('FNAVN').AsString, Customer.FirstName);
      StrToBuf(Query.FieldByName('ENAVN').AsString, Customer.LastName);
    
      Customer.CustomerNo := Query.FieldByName('KUNDENR').AsInteger;
    
    end;
