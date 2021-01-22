    void yourTabContainer_ActiveTabChanged(object sender, EventArgs e)
        {
          switch (yourTabContainer.ActiveTab.DynamicContextKey)
          {
            case "Key1":
              userControl1.Visible = false;
              userControl2.Visible = true;
              break;
            case "Key2":
              userControl1.Visible = true;
              userControl2.Visible = false;
              break;
           }
        }
