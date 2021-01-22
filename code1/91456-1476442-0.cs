    using System.Web.Mvc;
    [Bind(Exclude = "Height, Width")]
    public class MyModelClass {
        ....
    }
