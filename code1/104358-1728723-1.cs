    <Window.Resources>
        
        <local:TypeConverter x:Key="TypeConverter"/>
        
        <DataTemplate DataType="{x:Type sys:Exception}">
            <Expander Header="{Binding Converter={StaticResource TypeConverter}}">
                <Expander.Content>
                    <StackPanel Orientation="Vertical">
                        <TextBlock Text="{Binding Message}" />
                        <TextBlock Text="{Binding Source}"   />
                        <ContentPresenter Content="{Binding InnerException}"    />
                    </StackPanel>
                </Expander.Content>               
            </Expander>
        </DataTemplate>   
        
    </Window.Resources>
