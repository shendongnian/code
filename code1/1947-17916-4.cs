      public static void WriteControls
            (this HtmlTextWriter o, string format, params object[] args)
      { const string delimiter = "<2E01A260-BD39-47d0-8C5E-0DF814FDF9DC>";
        var controls  = new Dictionary<string,Control>();
     
        for(int i =0; i < args.Length; ++i)
         { var c = args[i] as Control; 
           if (c==null) continue;
           var guid = Guid.NewGuid().ToString();
           controls[guid] = c;
           args[i] = delimiter+guid+delimiter;
         }
      
        var _strings
           = string.Format(format, args).Split( new string[]{delimiter}
                                               ,StringSplitOptions.None);
        foreach(var s in _strings)
         { if (controls.ContainsKey(s)) controls[s].RenderControl(o);
           else o.Write(s);
         }
      }
