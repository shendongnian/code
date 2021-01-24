    using System.Collections;
    using UnityEngine;
    using System;
    using System.Collections.Generic;
    
    
    public class SampleWebView : MonoBehaviour
    {
    
        public string Url;
        public GUIText status;
        WebViewObject webViewObject;
    
    
        IEnumerator Start()
        {
            webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
            webViewObject.Init(
                cb: (msg) =>
                {
                    Debug.Log(string.Format("CallFromJS[{0}]", msg));
                    status.text = msg;
                    status.GetComponent<Animation>().Play();
                },
                err: (msg) =>
                {
                    Debug.Log(string.Format("CallOnError[{0}]", msg));
                    status.text = msg;
                    status.GetComponent<Animation>().Play();
                },
                started: (msg) =>
                {
                    Debug.Log(string.Format("CallOnStarted[{0}]", msg));
                },
                ld: (msg) =>
                {
                    Debug.Log(string.Format("CallOnLoaded[{0}]", msg));
    #if UNITY_EDITOR_OSX || !UNITY_ANDROID
                    // NOTE: depending on the situation, you might prefer
                    // the 'iframe' approach.
                    // cf. https://github.com/gree/unity-webview/issues/189
    #if true
                    webViewObject.EvaluateJS(@"
                      if (window && window.webkit && window.webkit.messageHandlers && window.webkit.messageHandlers.unityControl) {
                        window.Unity = {
                          call: function(msg) {
                            window.webkit.messageHandlers.unityControl.postMessage(msg);
                          }
                        }
                      } else {
                        window.Unity = {
                          call: function(msg) {
                            window.location = 'unity:' + msg;
                          }
                        }
                      }
                    ");
    #else
                    webViewObject.EvaluateJS(@"
                      if (window && window.webkit && window.webkit.messageHandlers && window.webkit.messageHandlers.unityControl) {
                        window.Unity = {
                          call: function(msg) {
                            window.webkit.messageHandlers.unityControl.postMessage(msg);
                          }
                        }
                      } else {
                        window.Unity = {
                          call: function(msg) {
                            var iframe = document.createElement('IFRAME');
                            iframe.setAttribute('src', 'unity:' + msg);
                            document.documentElement.appendChild(iframe);
                            iframe.parentNode.removeChild(iframe);
                            iframe = null;
                          }
                        }
                      }
                    ");
    #endif
    #endif
                    webViewObject.EvaluateJS(@"Unity.call('ua=' + navigator.userAgent)");
                },
                //ua: "custom user agent string",
                enableWKWebView: true);
    #if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
            webViewObject.bitmapRefreshCycle = 1;
    #endif
            webViewObject.SetMargins(10, 140, 10, Screen.height / 360);
            webViewObject.SetVisibility(true);
    
    #if !UNITY_WEBPLAYER
            if (Url.StartsWith("http")) {
                webViewObject.LoadURL(Url.Replace(" ", "%20"));
            } else {
                var exts = new string[]{
                    ".jpg",
                    ".js",
                    ".html"  // should be last
                };
                foreach (var ext in exts) {
                    var url = Url.Replace(".html", ext);
                    var src = System.IO.Path.Combine(Application.streamingAssetsPath, url);
                    var dst = System.IO.Path.Combine(Application.persistentDataPath, url);
                    byte[] result = null;
                    if (src.Contains("://")) {  // for Android
                        var www = new WWW(src);
                        yield return www;
                        result = www.bytes;
                    } else {
                        result = System.IO.File.ReadAllBytes(src);
                    }
                    System.IO.File.WriteAllBytes(dst, result);
                    if (ext == ".html") {
                        webViewObject.LoadURL("file://" + dst.Replace(" ", "%20"));
                        break;
                    }
                }
            }
    #else
            if (Url.StartsWith("http")) {
                webViewObject.LoadURL(Url.Replace(" ", "%20"));
            } else {
                webViewObject.LoadURL("StreamingAssets/" + Url.Replace(" ", "%20"));
            }
            webViewObject.EvaluateJS(
                "parent.$(function() {" +
                "   window.Unity = {" +
                "       call:function(msg) {" +
                "           parent.unityWebView.sendMessage('WebViewObject', msg)" +
                "       }" +
                "   };" +
                "});");
    #endif
            yield break;
        }
    
    #if !UNITY_WEBPLAYER
        //void OnGUI()
        //{
        //    GUI.enabled = webViewObject.CanGoBack();
        //    if (GUI.Button(new Rect(10, 10, 80, 80), "<")) {
        //        webViewObject.GoBack();
        //    }
        //    GUI.enabled = true;
    
        //    GUI.enabled = webViewObject.CanGoForward();
        //    if (GUI.Button(new Rect(100, 10, 80, 80), ">")) {
        //        webViewObject.GoForward();
        //    }
        //    GUI.enabled = true;
    
        //    GUI.TextField(new Rect(200, 10, 300, 80), "" + webViewObject.Progress());
        //}
    #endif
    
        
    
    
       
    
    
    }
