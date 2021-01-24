    public interface IExternalDataService
    {
       IEnumerable<SomeDto> Getdata();
    
       SomeDto Getdata(object id);
    }
