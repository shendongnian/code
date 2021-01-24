    {
        var obj1 = new Obj()
        {
            prop1 = int.TryParse(data.Rows[0]["RequestId"]?.ToString(), out int val) ? val : -1,
            prop2 = IsBoss = bool.TryParse(data.Rows[0]["IsBoss"].ToString(), out bool isBoss) ? isBoss : false
        }
    }
