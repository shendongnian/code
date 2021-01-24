    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="100"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <StackPanel>
            <Button Content="UC1" Click="UC1_Click"/>
            <Button Content="UC2" Click="UC2_Click"/>
        </StackPanel>
        <ContentControl Name="parent"
                        Grid.Column="1"
                        >
            <ContentControl.DataContext>
                <local:OneViewModel/>
            </ContentControl.DataContext>
        </ContentControl>
    </Grid>
