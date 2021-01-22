class Response < T > {
 public ResponseData < T > [] responseData = new ResponseData < T > [0];
 public HttpStatusCode responseStatus;
 public object responseDetails;
}
public class ResponseData < TInternal > {
 public TInternal responseData;
 public HttpStatusCode responseStatus;
 public object responseDetails;
}
public class TranslatedText {
 public string translatedText;
}
[Test]
public void Sample() {
 var input = @ " {
  ""
  responseData "": [{
    ""
    responseData "": {
     ""
     translatedText "": ""
     elefante ""
    },
    ""
    responseDetails "": null,
    ""
    responseStatus "": 200
   }, {
    ""
    responseData "": {
     ""
     translatedText "": ""
     Burro ""
    },
    ""
    responseDetails "": null,
    ""
    responseStatus "": 200
   }],
   ""
  responseDetails "": null, ""
  responseStatus "": 200
 }
 ";
 var json = new JavaScriptSerializer();
 var response = json.Deserialize < Response < TranslatedText >> (input);
 Assert.AreEqual(response.responseData[0].responseData.translatedText, "elefante");
 Assert.AreEqual(response.responseStatus, HttpStatusCode.OK);
}
