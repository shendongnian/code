    var iWB2 = (dynamic)webBrowser1.GetType().GetField("axIWebBrowser2",
        System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
        .GetValue(webBrowser1);
    int zoom = 300;
    iWB2.ExecWB(63, 2, zoom, ref zoom); 
