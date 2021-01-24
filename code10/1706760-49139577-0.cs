    private bool IsRockNRoll(Guid userID)
    {
        using (var context = new MyContext())
        {
            bool blnIsRockNRoll = false;
            var result = (from o in context.MyTableName.AsEnumerable()
                            where o.myTableColumnName.Contains(userID.ToString())
                            && o.myTableColumnName.Contains("RockNRoll")
                            select o).ToList();
    
            if (result.Count > 0)
            {
                blnIsRockNRoll = true;
            }
    
            return blnIsRockNRoll;
        }
    }
