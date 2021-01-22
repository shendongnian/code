            DropDownList ddl = new DropDownList();
            ListItem li0 = new ListItem(string.Empty, "0");
            ListItem li1 = new ListItem("Hello", "1");
            ListItem li2 = new ListItem("World", "2");
            ddl.Items.Add(li0);
            ddl.Items.Add(li1);
            ddl.Items.Add(li2);
            ddl.AutoPostBack = true;
            PlaceHolder1.Controls.Add(ddl);
            ddl.SelectedIndexChanged += delegate(object snd, EventArgs evt) { DoSomething(ddl.SelectedValue); };
        public void DoSomething(string SelectedValue)
        {
            //Do something spectacular here...
        }
