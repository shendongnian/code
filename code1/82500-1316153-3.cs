private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
{
    EventLogEntry entry = e.Entry;
    if (e.Entry.EventID == 1074)
    {
        File.AppendAllText(@"c:\message.txt", entry.Message);
    }
}
