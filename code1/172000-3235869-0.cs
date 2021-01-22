    internal class MyView : INotifyPropertyChanged {
       private string _postCode;
    
       public string PostCode {
          get { return _postCode; }
          set {
             _postCode = value;
             OnPropertyChanged("PostCode");
             OnPropertyChanged("FilteredItems");
          }
       }
    
       public ObservableCollection<Address> Items { get; set; }
    
       public IEnumerable<Address> FilteredItems {
          get { return Items.Where(o => o.PostCode == _postCode).ToArray(); }
       }
    
       public event PropertyChangedEventHandler PropertyChanged;
    
       private void OnPropertyChanged( string propertyName ) {
          if( PropertyChanged != null ) {
             PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }
       }
    }
    <Grid DataContext="{Binding Path=myViewInstance}">
       <TextBox Text="{Binding Path=PostCode, Mode=TwoWay}"/>
       <ListBox Grid.Row="0" Grid.Column="1" Grid.RowSpan="2" ItemsSource="{Binding Path=FilteredItems}">
          <ListBox.ItemsPanel>
             <ItemsPanelTemplate>
                <VirtualizingStackPanel
                   Orientation="Horizontal"
                   IsItemsHost="true"  />
             </ItemsPanelTemplate>
          </ListBox.ItemsPanel>
          <ListBox.ItemTemplate>
             <DataTemplate>
                <StackPanel Grid.Row="0" Grid.Column="1" Grid.RowSpan="2" Orientation="Vertical">
                   <Label Content="{Binding Address1}"></Label>
                   <Label Content="{Binding Address2}"></Label>
                   <Label Content="{Binding Town}"></Label>
                   <Label Content="{Binding PostCode}"></Label>
                   <Label Content="{Binding Country}"></Label>
                   <CheckBox Content="{Binding Include}"></CheckBox>
                </StackPanel>
             </DataTemplate>
          </ListBox.ItemTemplate>
       </ListBox>
    </Grid>
