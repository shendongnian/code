    <Window.DataContext>
        <local:MainWIndowViewModel/>
    </Window.DataContext>
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="100"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <ListBox ItemsSource="{Binding BrushesView}"
                 IsSynchronizedWithCurrentItem="True"
                 > 
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Ellipse Fill="{Binding}" Height="20" Width="20">
                        <Ellipse.Style>
                            <Style TargetType="Ellipse">
                                <Setter Property="Stroke"          Value="Gray"/>
                                <Setter Property="StrokeThickness" Value="1"/>
                                <Style.Triggers>
                                    <DataTrigger Binding="{Binding Path=IsSelected, RelativeSource={
                                           RelativeSource Mode=FindAncestor, AncestorType=ListBoxItem}}"
                                           Value="True">
                                        <Setter Property="Ellipse.Stroke" Value="Black"/>
                                        <Setter Property="Ellipse.StrokeThickness" Value="2"/>
                                    </DataTrigger>
                                    <Trigger Property="IsMouseOver" Value="True">
                                        <Setter Property="RenderTransform">
                                            <Setter.Value>
                                                <ScaleTransform ScaleX="1.2" ScaleY="1.2" />
                                            </Setter.Value>
                                        </Setter>
                                    </Trigger>
                                </Style.Triggers>
                            </Style>
                        </Ellipse.Style>
                    </Ellipse>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
        <Rectangle           
                   Grid.Column="1"
                   Width="40"
                   Height="40"
                   Fill="{Binding BrushesView/}"/>
    </Grid>
