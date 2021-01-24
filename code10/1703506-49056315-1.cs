    <Window x:Class="HorizontalDataGridMixedContentFromCalc.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:HorizontalDataGridMixedContentFromCalc"
            mc:Ignorable="d"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <DataGrid Name="DataGridTest" 
                      AutoGenerateColumns="False"
                      ItemsSource="{Binding Calculations, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" VerticalAlignment="Top">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="f" Binding="{Binding f}"></DataGridTextColumn>
                    <DataGridTextColumn Header="e" Binding="{Binding e}" ></DataGridTextColumn>
                    <DataGridTextColumn Header="d" Binding="{Binding d}" ></DataGridTextColumn>
                    <DataGridCheckBoxColumn Header="c" Binding="{Binding c}" ></DataGridCheckBoxColumn>
                    <DataGridTextColumn Header="b" Binding="{Binding b}" ></DataGridTextColumn>
                    <DataGridTextColumn Header="a" Binding="{Binding a}" ></DataGridTextColumn>
                </DataGrid.Columns>
                <DataGrid.LayoutTransform>
                    <TransformGroup>
                        <RotateTransform Angle="270"/>
                    </TransformGroup>
                </DataGrid.LayoutTransform>
                <DataGrid.ColumnHeaderStyle>
                    <Style TargetType="{x:Type DataGridColumnHeader}">
                        <Setter Property="LayoutTransform">
                            <Setter.Value>
                                <TransformGroup>
                                    <RotateTransform Angle="90"/>
                                </TransformGroup>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </DataGrid.ColumnHeaderStyle>
                <DataGrid.CellStyle>
                    <Style TargetType="DataGridCell">
                        <Setter Property="LayoutTransform">
                            <Setter.Value>
                                <TransformGroup>
                                    <RotateTransform Angle="90"/>
                                </TransformGroup>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </DataGrid.CellStyle>
            </DataGrid>
        </Grid>
    </Window>
