    var sapROTWrapper = new CSapROTWrapper();
    var sapGuilRot = sapROTWrapper.GetROTEntry("SAPGUI");
    var engine = sapGuilRot.GetType().InvokeMember("GetScriptingEngine", System.Reflection.BindingFlags.InvokeMethod, null, sapGuilRot, null);
    var guiApp = (GuiApplication)engine;
    var existingConnection = (GuiConnection)guiApp.Connections.ElementAt(0);
    var properConnectionString = existingConnection.ConnectionString;
