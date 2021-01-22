    <Query Kind="Program">
        <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
        <Namespace>System.Web.Script.Serialization;</Namespace>
    </Query>
    void Main()
    {
        var jsonData=Util.ReadLine<string>("Enter JSON string:");
        var jsonAsObject = new JavaScriptSerializer().Deserialize<object>(jsonData);
        jsonAsObject.Dump("Deserialized JSON");
    }
