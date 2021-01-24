    private void SendRenderEntryBroadcast(EntryDto entry)
    {
        Intent intent = new Intent("renderEntry");
        intent.PutExtra("html", GetEntryHtml(entry));
        SendBroadcast(intent);
    }
