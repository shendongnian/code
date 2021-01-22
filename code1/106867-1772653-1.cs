    public class OtherConcrete : IConcrete { }
    
    public void DoStuffWithInterfaceList(List<IConcrete> listOfInterfaces) 
    {
           listOfInterfaces.Add(new OtherConcrete ());
    }
