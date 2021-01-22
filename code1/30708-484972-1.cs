    <ListView>
        <ListView.Resources>
            <DataTemplate x:Key="IconTemplate">
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                    <Image Grid.Column="0"/>
                    <TextBlock Grid.Column="1" Text="{Binding Name}"/>
                </Grid>
            </DataTemplate>
        </ListView.Resources>            
        <ListView.View>		
            <GridView>
                <GridViewColumn CellTemplate="{StaticResource IconTemplate}" Header="Name"/>
                <GridViewColumn DisplayMemberBinding="{Binding Size}" Header="Size"/>
                <GridViewColumn DisplayMemberBinding="{Binding Type}" Header="Type"/>                    
            </GridView>
        </ListView.View>
    </ListView>
