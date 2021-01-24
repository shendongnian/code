    <Window x:Class="WpfApp1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:WpfApp1"
            mc:Ignorable="d"
            Title="MainWindow"
            Width="600"
            Height="500">
        <Window.DataContext>
            <local:MainWindowViewModel />
        </Window.DataContext>
        <Window.Resources>
            <local:TypeToSubTypesConverter
                x:Key="TypeToSubTypesConverter" />
        </Window.Resources>
        <Grid>
            <DataGrid
                AutoGenerateColumns="False"
                ItemsSource="{Binding Collection}">
                <DataGrid.Columns>
                    <DataGridComboBoxColumn
                        Header="Type"
                        SelectedItemBinding="{Binding Type, UpdateSourceTrigger=PropertyChanged}"> <!-- property changed so we get the change right after we select-->
                        <DataGridComboBoxColumn.ElementStyle>
                            <Style
                                TargetType="ComboBox">
                                <Setter
                                    Property="ItemsSource"
                                    Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}}, Path=DataContext.TypeCollection}" />
                            </Style>
                        </DataGridComboBoxColumn.ElementStyle>
                        <DataGridComboBoxColumn.EditingElementStyle>
                            <Style
                                TargetType="ComboBox">
                                <Setter
                                    Property="ItemsSource"
                                    Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}}, Path=DataContext.TypeCollection}" />
                            </Style>
                        </DataGridComboBoxColumn.EditingElementStyle>
                    </DataGridComboBoxColumn>
                <DataGridComboBoxColumn
                    Header="Sub Type"
                    SelectedItemBinding="{Binding SubType, UpdateSourceTrigger=PropertyChanged}"> <!-- property changed so we get the change right after we select-->
                    <DataGridComboBoxColumn.ElementStyle>
                        <Style
                            TargetType="ComboBox">
                            <Setter
                                Property="ItemsSource">
                                <Setter.Value>
                                    <MultiBinding
                                        Converter="{StaticResource ResourceKey=TypeToSubTypesConverter}">
                                        <Binding
                                            Path="Type" />
                                        <Binding
                                            Path="DataContext.SubTypeCollection"
                                            RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType={x:Type Window}}"/>
                                    </MultiBinding>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </DataGridComboBoxColumn.ElementStyle>
                    <DataGridComboBoxColumn.EditingElementStyle>
                        <Style
                            TargetType="ComboBox">
                            <Setter
                                Property="ItemsSource">
                                <Setter.Value>
                                    <MultiBinding
                                        Converter="{StaticResource ResourceKey=TypeToSubTypesConverter}">
                                        <Binding
                                            Path="Type" />
                                        <Binding
                                            Path="DataContext.SubTypeCollection"
                                            RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType={x:Type Window}}" />
                                    </MultiBinding>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </DataGridComboBoxColumn.EditingElementStyle>
                </DataGridComboBoxColumn>
            </DataGrid.Columns>
            </DataGrid>
        </Grid>
    </Window>
