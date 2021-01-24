    public void Cmd_OnDataReceivedDeserialized(RequestResponse response)
    {
        LoPyList.Add(new LoPy() { name = "Test", id = "00" });
        RaisePropertyChangedEvent(nameof(LoPyList));
    }
