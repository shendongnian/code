    string.Join(
        "\n",
        db.MsgHistory
        .Where(s => s.FK_MsgHistory_MsgID.Id == id)
        .Where(s => !string.IsNullOrEmpty(s.Message))
        .Select(s => s.Message))
