      public void DoSomething() 
      {
        searchForm.Show();
        searchForm.SearchTerm = this.TextBox1.Text;
        searchForm.FormClosing += new FormClosingEventHandler(searchForm_FormClosing);
        this.Enabled = false
      }
      void searchForm_FormClosing(object sender, FormClosingEventArgs e)
      {
        this.Enabled = true;
        // Get result from search form here
        MyItem result = searchForm.GetItem();
        if(MyItem != MyItem.Empty) // do something
      }
