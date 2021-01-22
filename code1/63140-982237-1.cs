    HtmlElement videoPlugin = HtmlPage.Document.GetElementById("VideoPlayer");
                if (videoPlugin != null)
                {
                    ScriptObject mediaPlayer = (ScriptObject)((ScriptObject)videoPlugin.GetProperty("Content")).GetProperty("Page");
    
                    mediaPlayer.Invoke("SeekPlayback", TimeSpan.FromSeconds(seconds).ToString());
    
                }
