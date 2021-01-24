using System;
class Person
{
    public string name { get; set; }
}
static System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
static System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
public const string endpoint = "some_valid_endpoint";
Person person = null;
// Use Http Client to fetch JSON from a given endpoint
System.Net.Http.HttpResponseMessage response = await client.GetAsync(endpoint);
// Parse JSON from response
string jsonString = await response.Content.ReadAsStringAsync();
// Store object in variable of type Person
person = serializer.Deserialize<Person>(jsonString);
tbh, I'm not sure how ScripCS handles Async, so there's some work to do to figure that out.
ScriptCS can be used to run standalone scripts or as a REPL, so you can test it locally.
