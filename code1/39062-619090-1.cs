    //in presenter
    var dataItems = _someService.GetData();
    _view.Data = dataItems;
    
    //in view code-behind
    public ICollection<DataItem> Data
    {
        get; set; //omitted for brevity - will require change notification
    }
    
    //in view XAML
    <ListView ItemsSource="{Binding Data}">
      <ListView.View>
        <GridView>
          <GridViewColumn DisplayMemberBinding="{Binding Path=Name}"/> 
          <GridViewColumn DisplayMemberBinding="{Binding Path=Age}"/> 
        </GridView>
      </ListView.View>
    </ListView>
