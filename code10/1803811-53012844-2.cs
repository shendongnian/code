    {
       if(!(int.TryParse(data.Rows[0]["RequestId"]?.ToString(), out int requestId)))
        {
            requestId = -1;
        }
        bool.TryParse(data.Rows[0]["IsBoss"]?.ToString(), out IsBoss);
        var obj1 = new Obj()
        {
            prop1 = requestId,
            prop2 = IsBoss
        }
    }
