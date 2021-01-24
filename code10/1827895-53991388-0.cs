    <Grid>
        <DataGrid Name="dgDiffs" AutoGenerateColumns="False">
            <DataGrid.Resources>
                <Style TargetType="DataGridRow">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding diff}" Value="2">
                            <Setter Property="Background" Value="Orange" />
                        </DataTrigger>
                        <DataTrigger Binding="{Binding diff}" Value="1">
                            <Setter Property="Background" Value="LightGreen" />
                        </DataTrigger>
                        <DataTrigger Binding="{Binding diff}" Value="-1">
                            <Setter Property="Background" Value="OrangeRed" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
                <Style TargetType="ScrollBar">
                    <Setter Property="Background">
                        <Setter.Value>
                            <ImageBrush ImageSource="{Binding Path=overview}" />
                            <!--<ImageBrush ImageSource="overview.png" />-->
                        </Setter.Value>
                    </Setter>
                </Style>
            </DataGrid.Resources>
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding leftString}" Width="200"></DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding rightString}" Width="*"></DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
