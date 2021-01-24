    public void WriteEventsToFile(MyEventObject myEvent, string path)
    {
      WriteEventsToFileHelper(myEvent, path);
    }
    public void WriteEventsToFile(List<MyEventObject> myEvent, string path)
    {
      WriteEventsToFileHelper(myEvent, path);
    }
    private void WriteEventsToFileHelper(object myEvent, string path) 
    {
      Debug.Assert(myEvent is MyEventObject || myEvent is List<MyEventObject>);
      ...
