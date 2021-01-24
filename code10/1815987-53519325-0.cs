    <ListBox ItemsSource="{Binding WeeklyWeather}"
             SelectedItem="{Binding SelectedDailyWeather, Mode=TwoWay}">
        //Use ItemTemplate to set how item looks "inside"
        //I'll leave design details for you
        <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel>
                    <TextBlock Text="{Binding Day}"/>
                    <Image Source={Binding WheatherPicturePath}/>
                    <TextBlock Text="{Binding Temperature}"/>
                    <TextBlock Text="{Binding Description}"/>
                </StackPanel>
            </DataTemplate>
        </ListBox.ItemTemplate>
        
        //ItemsPanel defines container for items. It can be StackPanel, Wrapanel, Grid, etc
        <ListBox.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel IsItemsHost="True" Orientation="Horizontal"/>
            </ItemsPanelTemplate>
        </ListBox.ItemsPanel>
        <ListBox.ItemContainerStyle>
            <Style TargetType="ListBoxItem">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type ListBoxItem}">
                            //You use this place to design how container normally looks like
                            <Border Background="White">
                                //DataTemplate defined above is placed in ContentPresenter
                                <ContentPresenter />
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    //Here we catch "IsSelected" event and re-design our template to visually reflect "selected"
                    <Trigger Property="IsSelected" Value="true">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type ListBoxItem}">
                                    <Border Background="Gray">
                                        <ContentPresenter />
                                    </Border>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ListBox.ItemContainerStyle>
    </ListBox>
    
