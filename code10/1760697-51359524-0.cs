    <ComboBox Name="myComboBox"
              ItemsSource="{Binding MyCollection}"
              SelectedItem="{Binding Path=MySelectedItem}">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <TextBlock>
                    <TextBlock.Style>
                        <Style TargetType="TextBlock">
                            <Setter Property="Text" Value="{Binding Value}" />
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding Value}" Value="0">
                                    <Setter Property="Text" Value="..." />
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </TextBlock.Style>
                </TextBlock>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox> 
