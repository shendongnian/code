    void radTabEmailSelector_ActiveTabChanged(object sender, EventArgs e)
        {
          switch (radTabEmailSelector.ActiveTab.DynamicContextKey)
          {
            case "UserSelector":
              mw.ActiveViewIndex = 0;
              break;
            case "GroupSelector":
              if (SiteGroupSelector1.SelectedGroupID.Count == 0)
              {
                LoadTemporaryEmailSelectorWrapper();
                SiteGroupSelector1.SelectedGroupID = CurrentEmailSelectorWrapper.GroupIDList;
              }
              mw.ActiveViewIndex = 1;
              break;
            case "CustomSelector":
              mw.ActiveViewIndex = 2;
              LoadTemporaryEmailSelectorWrapper();
              _gridView.DataSource = CurrentEmailSelectorWrapper.CustomMailAddressList;
              _gridView.DataBind();
              break;
          }
        }
