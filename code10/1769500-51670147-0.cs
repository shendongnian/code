      async void OnTapped(object sender, System.EventArgs e)
      {
         var btn = sender as ButtonTemplate;
         if (btn == null)
            return;
         if (btn.Text == Settings.cc.ShortText())
            return;
         if (Counts.phaseTableSelectedCardCount != 0)
         {
            var canContinue = await this.DisplayAlert("Selector", "Changing this will remove all previously selected cards from the deck", "OK", "Cancel");
            if (canContinue == false)
               return;
         }
         var settingId = SetButtons(btn.Text);
         await Task.Run(() => AddDetailSection(settingId));
      }
      public void AddDetailSection(int settingId)
      {
         App.DB.UpdateSelected(false);
         App.DB.UpdateIntSetting(SET.Cc, settingId);
         AddDetailSection();
         vm.IsBusy = true;
         Change.cardSelection = true;
         App.DB.GetData();
         detailsLayout.Children.Clear();
         detailsLayout.Children.Add(CreateDetailSection(null));
         SetPageDetails();
         vm.IsBusy = false;
      }
