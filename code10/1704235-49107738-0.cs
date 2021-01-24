    <Window x:Class="WpfApplication1.Window1"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:this="clr-namespace:WpfApplication1"
            Title="Window1" Height="300" Width="300">
    
        <Window.Resources>
            <this:RowDataConverter x:Key="RowDataConverter1" />
        </Window.Resources>
        <Grid>
        
            <DataGrid ItemsSource="{Binding Rows, Mode=OneWay}">
                <DataGrid.Columns>
                    <DataGridTextColumn>
                        <DataGridTextColumn.Binding>
                            <MultiBinding Converter="{StaticResource RowDataConverter1}">
                                <Binding Path="Column1" Mode="OneWay" />
                                <Binding Path="Column1OptionString" Mode="OneWay" RelativeSource="{RelativeSource AncestorType=Window, Mode=FindAncestor}" />
                            </MultiBinding>
                        </DataGridTextColumn.Binding>
                    
                        <DataGridTextColumn.HeaderTemplate>
                            <DataTemplate>
                                <StackPanel>
                                    <TextBlock Text="Column Header 1" />
                                    <ComboBox ItemsSource="{Binding ColumnOptions, Mode=OneWay, RelativeSource={RelativeSource AncestorType=Window, Mode=FindAncestor}}"
                                              SelectedValue="{Binding Column1OptionString, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged, RelativeSource={RelativeSource AncestorType=Window, Mode=FindAncestor}}"
                                              SelectedValuePath="Option">
                                        <ComboBox.ItemTemplate>
                                            <DataTemplate DataType="this:ColumnOption">
                                                <TextBlock Text="{Binding Option, Mode=OneTime}" />
                                            </DataTemplate>
                                        </ComboBox.ItemTemplate>
                                    </ComboBox>
                                </StackPanel>
                            </DataTemplate>
                        </DataGridTextColumn.HeaderTemplate>
                    </DataGridTextColumn>
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
    </Window>
