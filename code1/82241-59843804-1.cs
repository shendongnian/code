    public class Item : INotifyPropertyChanged
    {
        public string Title                     { get; set; } // TODO: Notify on change
        public bool VisibleSelf                 { get; set; } // TODO: Notify on change
        public bool VisibleChildOrSelf          { get; set; } // TODO: Notify on change
        public ObservableCollection<Item> Items { get; set; } // TODO: Notify on change
        public void CheckVisibility(string searchText)
        {
             VisibleSelf = // Title contains SearchText. You may use RegEx with wildcards
             VisibleChildOrSelf = VisibleSelf;
             foreach (var child in Items)
             {
                 child.CheckVisibility(searchText);
                 VisibleChildOrSelf |= child.VisibleChildOrSelf;
             }
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Item> Source { get; set; } // TODO: Notify on change
        public string SearchText                 { get; set; } // TODO: Notify on change
        private void OnSearchTextChanged()  // TODO: Action should be delayed by 500 millisec
        {
            foreach (var item in Source) item.CheckVisibility(SearchText);
        }
    }
    <StackPanel>
        <TextBox Text="{Binding SearchText, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" 
                     MinWidth="200" Margin="5"/>
    
        <TreeView ItemsSource="{Binding Source}" Margin="5">
            <TreeView.ItemTemplate>
                <HierarchicalDataTemplate ItemsSource="{Binding Items}">
                    <TextBlock Text="{Binding Title}" />
                </HierarchicalDataTemplate>
            </TreeView.ItemTemplate>
            <TreeView.ItemContainerStyle>
                <Style TargetType="Control">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding VisibleChildOrSelf}" Value="false">
                            <Setter Property="Visibility" Value="Collapsed"/>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding VisibleSelf}" Value="false">
                            <Setter Property="Foreground" Value="Gray"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </TreeView.ItemContainerStyle>
        </TreeView>
    <StackPanel>
