    public class Item
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Thickness Margin { get; set; }
        public Brush Fill { get; set; }
    }
----------
    <ItemsControl ItemsSource="{Binding Items}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas Background="#FFF1F0F0" Margin="10" />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Rectangle Width="{Binding Width}" 
                           Height="{Binding Height}" 
                           Margin="{Binding Margin}"
                           Fill="{Binding Fill}" />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
