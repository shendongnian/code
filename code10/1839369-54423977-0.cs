    private string MergeMessage(ConnectTo db, Guid id)
    {
        return string.Join(", ",
            db.MsgHistory
            .Where(s => s.FK_MsgHistory_MsgID.Id == id)
            .Where(s => !string.IsNullOrEmpty(s.Message))
            .Select(s => s.Message))
    }
