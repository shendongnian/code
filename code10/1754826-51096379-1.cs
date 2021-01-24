    <ComboBox SelectedIndex="0">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                    
                    <Border Background="{Binding}" Height="20" Width="24" Margin="2"/>
                    <TextBlock Grid.Column="1" Margin="5,0" VerticalAlignment="Center" Text="{Binding}"/>
                </Grid>
            </DataTemplate>
        </ComboBox.ItemTemplate>
        
        <ComboBox.Items>
            <system:String>Blue</system:String>
            <system:String>Red</system:String>
            <system:String>Green</system:String>
            <system:String>Orange</system:String>
            <system:String>Pink</system:String>
            <system:String>Purple</system:String>
        </ComboBox.Items>
    </ComboBox>
