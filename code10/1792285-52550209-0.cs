    public List<object> SerialNumbers
    {
        get => this._serialNumbersProperty;
        set
        {
            if (!List<object>.Equals(value, this._serialNumbersProperty))
            {
                this._serialNumbersProperty = value;
                OnPropertyChanged(nameof(this.SerialNumbers));
            }
        }
    }
    <ListBox x:Name="SerialNumbersListBox"
         AllowDrop="True"
                 Grid.ColumnSpan="2"
                 Grid.Row="2"
         ItemsSource="{Binding SerialNumbers}">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <CheckBox Content="{Binding name}"
                      IsChecked="{Binding IsSelected}"/>
                </DataTemplate>
            </ListBox.ItemTemplate>
    </ListBox>
