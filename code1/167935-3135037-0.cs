    public class NameField : Control
    {
        private const String ElementPrefixBox        = "PART_PrefixBox";
        public ObservableCollection<NamePrefix> NamePrefixes {get;private set;}
        public NameField()
        {
            NamePrefixes = new ObservableCollection<NamePrefix>();
        }
    }
    <Style TargetType="{x:Type local:NameField}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type local:NameField}">
                    <StackPanel Orientation="Horizontal">
                        <TextBlock TextWrapping="NoWrap" Text="Name:" VerticalAlignment="Center" Margin="3" />
                        <ListBox x:Name="PART_PrefixBox" 
                            VerticalAlignment="Center" 
                            Margin="3" 
                            ItemsSource="{Binding NamesPrefix, RelativeSource={RelativeSource FindAncestor, Ancestortype=Whatever}}" />
                    </StackPanel>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
