    private void WriteEventsToFile(MyEventObject myEvent, string path) {
        WriteEventsToFile(new[] {myEvent}, path);
    }
    private void WriteEventsToFile(ICollection<MyEventObject> myEvents, string path)
    {
        string eventObject = JsonConvert.SerializeObject(myEvents);
        try
        {
            System.IO.File.WriteAllText(path, eventObject);
        }
        catch (Exception e)
        {
            Debug.WriteLine("System.IO.File.WriteAllText Exception : " + e.Message + "\nCall Stack : " + e.StackTrace);
            throw;
        }
    }
