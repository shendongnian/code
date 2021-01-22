    // model class
    public class Widget : INotifyPropertyChanged
    {
      public string Description { ... }
    }
    
    <!-- view -->
    <DataTemplate>
      <TextBox Text="{Binding Description}" />
    </DataTemplate>
