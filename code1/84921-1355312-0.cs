    class PluginUIBuilder {
        public void Fill(IPluginSystem p) {
           var t = ((object)p).GetType();
           foreach (var pi in t.GetProperties()) {
              if (pi.GetCustomAttributes(typeof(ExternalInput), true).Length > 0) {
                 string value = Prompt(pi.Name);
                 pi.SetValue(p, value, null);
              }
           }
        }
        string Prompt(string name) {
           using (var f = new InputForm()) {
              f.Prompt = "Enter a value for " + name;
              if (f.ShowDialog() = DialogResult.OK) {
                 return f.Value;
              }
              return null;
           }
        }
    }
    // client code
    var p = new MyPlugin();
    var ui = new PluginUIBuilder();
    ui.Fill(p);
    p.Execute();
