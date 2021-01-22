        <Window.Resources>
            <BooleanToVisibilityConverter x:Key="BoolToVis"/>
        </Window.Resources>
        <StackPanel>
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                </Grid.ColumnDefinitions>
                <ToggleButton x:Name="ToggleButton" Grid.Column="0" Content="+"/>
                <Label Grid.Column="1" Content="Max"/>
                <Label Grid.Column="2" Content="20"/>
                <Label Grid.Column="3" Content="Switzerland"/>        
            </Grid>
            <StackPanel Visibility="{Binding ElementName=ToggleButton, Path=IsChecked, Converter={StaticResource BoolToVis}}">
                <Label Content="Lastname: Eastwood"/>
                <Label Content="Phone: 0041 11 222 33 44"/>
            </StackPanel>
        </StackPanel>
