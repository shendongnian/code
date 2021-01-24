    <Window.DataContext>
            <local:ViewModel />
        </Window.DataContext>
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto" />
                <RowDefinition Height="*" />
            </Grid.RowDefinitions>
            <Button Content="Add Subject" Command="{Binding AddSubjectCommand}" Width="100" Height="30" HorizontalAlignment="Left" />
            <DataGrid Grid.Row="1" x:Name="SubjectsList" ItemsSource="{Binding Subjects}" Height="500" ScrollViewer.CanContentScroll="True" AutoGenerateColumns="False" CanUserAddRows="False">
                <DataGrid.Columns>
                    <DataGridTemplateColumn Header="Subject" Width="100">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding Name}" />
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                    <DataGridTemplateColumn Header="Weekly" Width="100">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding ClassesPerWeek}" />
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
