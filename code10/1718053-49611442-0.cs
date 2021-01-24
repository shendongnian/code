     public class form1
     {
       Forms.Timer tmr = new Forms.Timer
       private void form_Load()
        {
          tmr.Tick += tmr_Tick();
          tmr.Start
          me.Hide();
        }
      private void tmr_Tick()
      {
       FileSystemWatcher watcher = new FileSystemWatcher();
       watcher.Path = path;
       watcher.NotifyFilter = NotifyFilters.LastWrite;
       watcher.Filter = "*.*";
       watcher.Changed += new FileSystemEventHandler(OnChanged);
       watcher.EnableRaisingEvents = true;
      }
       private void OnChanged(object source, FileSystemEventArgs e)
      {
      //Copies file to another directory.
      }
