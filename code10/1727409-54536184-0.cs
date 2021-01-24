NuGet
//Nuget
Install-Package M6T.Core.TupleModelBinder -Version 1.0.0
//dotnet cli
dotnet add package M6T.Core.TupleModelBinder --version 1.0.0
# Usage
Modify startup.cs like
C#
using M6T.Core.TupleModelBinder;
....
public void ConfigureServices(IServiceCollection services)
{
  services.AddMvc(options =>
  {
      options.ModelBinderProviders.Insert(0, new TupleModelBinderProvider());
  });
}
Post request body 
json
{
  "user" : {
    "Name":"Test",
    "Surname":"Test2",
    "Email":"example@example.com"
  },
  "someData" : "If you like it, you put a data on it"
}
And in your controller use it like 
C#
[HttpPost]
public IActionResult CreateUser((User user, string someData) request)
{
    using (var db = new DBContext())
    {
        var newUser = db.Users.Add(request.user);
        db.SaveChanges();
        return Json(new { userId = request.user.Id, someData = request.someData});
    }
}
  [1]: https://github.com/m6t/M6T.Core.TupleModelBinder/blob/master/README.md
