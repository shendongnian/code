    <ListBox ItemsSource="{Binding PictureImagesList}">
        <ListBox.Template>
            <ControlTemplate TargetType="ListBox">
                <ScrollViewer HorizontalScrollBarVisibility="Disabled"
                              VerticalScrollBarVisibility="Auto">
                    <ItemsPresenter/>
                </ScrollViewer>
            </ControlTemplate>
        </ListBox.Template>
        <ListBox.ItemsPanel>
            <ItemsPanelTemplate>
                <UniformGrid Columns="4" HorizontalAlignment="Left" VerticalAlignment="Top"/>
            </ItemsPanelTemplate>
        </ListBox.ItemsPanel>
        <ListBox.ItemTemplate>
            <DataTemplate>
                <Image Source="{Binding}"/>
            </DataTemplate>
        </ListBox.ItemTemplate>
        <ListBox.ItemContainerStyle>
            <Style TargetType="ListBoxItem">
                <Setter Property="Background" Value="LightGray" />
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type ListBoxItem}" >
                            <Grid Background="{TemplateBinding Background}">
                                <Border HorizontalAlignment="Center" VerticalAlignment="Center"
                                        BorderThickness="5"
                                        BorderBrush="{TemplateBinding BorderBrush}">
                                    <ContentPresenter />
                                </Border>
                            </Grid>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsSelected" Value="True">
                                    <Setter Property="BorderBrush" Value="Yellow" />
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ListBox.ItemContainerStyle>
    </ListBox>
