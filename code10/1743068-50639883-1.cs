    <Style TargetType="local:Picker" >
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="local:Picker">
                    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="*"/>
                                <ColumnDefinition Width="*"/>
                            </Grid.ColumnDefinitions>
                            <StackPanel>
                                <Border Height="50" BorderBrush="Blue" BorderThickness="5">
                                    <Border.Background>
                                        <SolidColorBrush Color="{Binding Color}" />
                                    </Border.Background>
                                </Border>
                                <Popup Name="myPopup" IsOpen="False" IsLightDismissEnabled="True">
                                    <Grid Width="650" Height="300" >
                                        <ItemsControl ItemsSource="{TemplateBinding MyColors}">
                                            <ItemsControl.ItemTemplate>
                                                <DataTemplate>
                                                    <Grid>
                                                        <Border BorderThickness="15" BorderBrush="{Binding}">
                                                        </Border>
                                                    </Grid>
                                                </DataTemplate>
                                            </ItemsControl.ItemTemplate>
                                        </ItemsControl>
                                    </Grid>
                                </Popup>
                            </StackPanel>
                            <Button Grid.Column="1" Name="btn1" Height="55" Content="Click me"/>
                        </Grid>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
