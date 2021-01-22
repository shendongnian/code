    public class ViewModel
    {
      [MyAddAttribute("class", "myclass")]
      public string StringValue { get; set; }
    }
    public class MyExtensions
    {
      public static IDictionary<string, object> GetMyAttributes(object model)
      {
         // kind of prototype code...
         return model.GetType().GetCustomAttributes(typeof(MyAddAttribute)).OfType<MyAddAttribute>().ToDictionary(
              x => x.Name, x => x.Value);
      }
    }
    <!-- in the template -->
    <%= Html.TextBox("Name", Model, MyExtensions.GetMyAttributes(Model)) %>
