    using System.Web.Script.Serialization;
    // ...
    JavaScriptSerializer jss = new JavaScriptSerializer();
    string output = jss.Serialize(myList);
    UnityWebRequest www = UnityWebRequest.Post("http://ipaddress:5000/", output);
    yield return www.SendWebRequest();
