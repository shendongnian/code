    ItemsPage newPage = null;
    void Klaar_clicked(object sender, EventArgs e)
    {
        if (newPage == null) {
          newPage = new ItemsPage()
        }
        App.Current.MainPage = new NavigationPage(newPage);
    }
