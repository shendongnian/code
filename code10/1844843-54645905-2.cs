    public class Common<T>
      where T: class
    {
      //... common fields here
      public T Data {get;}
      public Common(T data) => Data = data;
    }
    ...
    var area = new Common(new Area(){...});
    //area.LoginId;
    //area.Data.AreaId;
