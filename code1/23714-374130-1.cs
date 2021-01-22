        protected void Page_Load(object sender, EventArgs e)
        {
            Control ctrl = this.LoadControl("WebUserControl1.ascx");
            PropertyInfo propertyInfo = typeof(Control).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            EventHandlerList eventHandlerList = propertyInfo.GetValue(ctrl, new object[]{}) as EventHandlerList;
            FieldInfo fieldInfo = typeof(Control).GetField("EventLoad", BindingFlags.NonPublic | BindingFlags.Static);
            if(fieldInfo == null)
                return;
            object eventKey = fieldInfo.GetValue(ctrl);
            Delegate eventHandler = eventHandlerList[eventKey] as Delegate;
            foreach(EventHandler item in eventHandler.GetInvocationList()) {
                ctrl.Load -= item;
            }
            ctrl.Load += ctrl_Load;
            foreach (EventHandler item in eventHandler.GetInvocationList()){
                ctrl.Load += item;
            }
            ctrl.Load += ctrl_Load;
            this.Controls.Add(ctrl);
        }
        void ctrl_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
