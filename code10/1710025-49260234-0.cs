    List<string> Data { get; set; }
    
    public Page2(List<string> data) {
      this.Data = data;
    }
    public override void OnAppearing() {
      MyListView.ItemsSource = Data;
    }
