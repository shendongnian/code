    public class ServerResponse<T extends JavascriptObject> 
      extends JavaScriptObject {
      protected ServerResponse() { }
      public final native T getPayload() /*-{ return this.Payload; }-*/;
      public final native boolean getSuccess() /*-{ return this.Success; }-*/;
      public final native String getMessage() /*-{ return this.Message; }-*/;
    }
