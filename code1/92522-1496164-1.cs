    class SampleObject //I don't want to make this a generic but am forced to
        {
    
            //The SampleContainer this object is in
            //This must be located in this base class
            public SampleContainer<SampleObject> Parent;//{ get; set; }
        }
    
        class SpecificObject : SampleObject
        //SampleObject<SpecificObject> !!? This is the bizzare bit
        //It seems really strange but necessary for compilation to work
        {
        }
    
    
        //A class to contain a List of objects derived from SampleObjects
        class SampleContainer<T>
        {
            public List<T> List;
        }
    
    
        class Start
        {
            public void Test()
            {
                SampleContainer<SampleObject> container = new SampleContainer<SampleObject>();
    
                SpecificObject o = new SpecificObject(); //create an object
                container.List.Add(o); //add it to the list
                o.Parent = container; //set its parent
            }
        }
