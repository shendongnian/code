        <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        
        <DataGrid Grid.Row="0"
                  ItemsSource="{Binding ListOfEntries}"
                  AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn  Header="Name" Binding="{Binding StrName}"/>
                <DataGridTextColumn  Header="Age" Binding="{Binding StrAge}"/>
            </DataGrid.Columns>
        </DataGrid>
        <ListView Grid.Row="1" ItemsSource="{Binding ListOfEntries}"
                  IsHitTestVisible="False" Focusable="False">
            <ListView.View>
                <GridView>
                    <GridView.Columns>
                        <GridViewColumn Header="Name" DisplayMemberBinding="{Binding StrName}"/>
                        <GridViewColumn Header="Age" DisplayMemberBinding="{Binding StrAge}"/>
                    </GridView.Columns>
                </GridView>
            </ListView.View>
        </ListView>
    </Grid>
