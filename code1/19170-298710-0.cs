        <ListBox ItemsSource="{Binding}">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition></RowDefinition>
                            <RowDefinition></RowDefinition>
                        </Grid.RowDefinitions>
                        
                        <Grid Grid.Row="0" Height="20" >
                            <TextBlock Text="Not Selected"></TextBlock>
                        </Grid>
                        <Grid x:Name="selectedOnlyGrid" Grid.Row="1" Visibility="Collapsed">
                            <TextBlock Text="Selected"></TextBlock>
                        </Grid>
                        
                    </Grid>
                    <DataTemplate.Triggers>
                        <DataTrigger Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type ListBoxItem}, AncestorLevel=1}, Path=IsSelected}" Value="True">
                            <Setter Property="Visibility" Value="Visible" TargetName="selectedOnlyGrid" />
                        </DataTrigger>
                    </DataTemplate.Triggers>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
