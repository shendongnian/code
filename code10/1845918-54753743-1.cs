 lang-csh
using Newtonsoft.Json.Linq;
public string FunctionHandler(JObject jsonContent, ILambdaContext context) {
    Message clientMessage = jsonContent.ToObject<Message>();
    // ...
    Message response = new Message();
    return JObject.FromObject(response).ToString();
}
Unity has support for JSON built in. My original code was close...
 lang-csh
private static void SendMessageToServerless(Message message) {
    string uri = "https://example.com/test";
    instance.StartCoroutine(SendMessageToServerlessAsync(uri, message));
}
private static IEnumerator SendMessageToServerlessAsync(string uri, Message message) {
    string jsonMessage = JsonUtility.ToJson(message);
    UnityWebRequest webRequest = UnityWebRequest.Put(uri, JsonUtility.ToJson(message));
    yield return webRequest.SendWebRequest();
    if (webRequest.isNetworkError) {
        Debug.LogError("Network error: " + webRequest.error);
    } else { 
        Debug.Log(webRequest.downloadHandler.text);
    }
}
