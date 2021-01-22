	class Form : System.Windows.Forms.Form
	{
     public void DisplayNotification(Data data)
     {
       //actual code here
     }
    }
    class Controller 
    {
        private Form form;
        private MyCustomWatcher watcher;
        public void Init()
        {
          this.watcher = CreateWatcher();
          RegisterEvents();
          ShowForm();
        }
        void ShowForm()
        {
         //show
        }
		void RegisterEvents()
		{
			this.watcher.Event += HandleChange;
		}
		void HandleChange(object sender /*this will be the instance that raised the event*/, SomeEventArgs e)
		{
            //BTW: this.watcher == sender; //the same instance
			form.DisplayNotification(this.watcher.GetData());
		}
	}
