    public void writeOutCustomObject(StreamWriter writer) {
       SomeObject theObject = getSomeCustomObject();
    
       writer.WriteLine("ID: " + theObject.ID);
       writer.WriteLine("Description: " + theObject.Description);
       //.... etc ....
    }
