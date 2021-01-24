    <ComboBox Margin="2,2,2,0" ItemsSource="{Binding DataContext.AllTags, ElementName=self}" >
        <ComboBox.ItemContainerStyle>
            <Style TargetType="ComboBoxItem">
                <Setter Property="HorizontalContentAlignment" Value="Stretch" />
            </Style>
        </ComboBox.ItemContainerStyle>
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <CheckBox IsChecked="{Binding IsChecked}" Content="Name">
                    <i:Interaction.Triggers>
                            <i:EventTrigger EventName="Checked">
                                <i:InvokeCommandAction Command="{Binding DataContext.CmdCmx_UpdateTags, ElementName=self}" CommandParameter="{Binding}" />
                            </i:EventTrigger>
                            <i:EventTrigger EventName="Unchecked">
                                <i:InvokeCommandAction Command="{Binding DataContext.CmdCmx_UpdateTags, ElementName=self}" CommandParameter="{Binding}"/>
                            </i:EventTrigger>
                     </i:Interaction.Triggers>
                </CheckBox>
            </DataTemplate>
        </ComboBox.ItemTemplate>
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="DropDownOpened">
                <i:InvokeCommandAction Command="{Binding DataContext.CmdCmx_ClearTags, ElementName=self}" />
            </i:EventTrigger>
        </i:Interaction.Triggers>
    </ComboBox>
