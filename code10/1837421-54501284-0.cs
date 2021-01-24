    [assembly: PreApplicationStartMethod(typeof(DreamyTools.DataBase.Web.MyModule1), "Initialize")]
     namespace DataBase.Web
      {
       public class MyModule1 : IHttpModule
       {
         public static void Initialize()
          {
               Microsoft.Web.Infrastructure.DynamicModuleHelper
               .DynamicModuleUtility.RegisterModule(MyModule1);
           }
