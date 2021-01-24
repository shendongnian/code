    <Grid>
        <ListBox ItemsSource="{Binding Items}" 
                 SelectedItem="{Binding MyItem}"/>
    </Grid>
.
    public class ViewModel : INotifyPropertyChanged
    {
        public string MyItem {get; set;}
    }
