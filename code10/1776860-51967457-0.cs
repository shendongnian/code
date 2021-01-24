    @using System.Web.Script.Serialization
    @{
        var serializer = new JavaScriptSerializer();
    }
    <script>
        var numbers = @Html.Raw(serializer.Serialize(Model.numbers));
    </script>
