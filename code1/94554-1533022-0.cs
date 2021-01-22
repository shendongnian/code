                            <ToggleButton Grid.Row="0" Grid.Column="2" Grid.RowSpan="2" VerticalAlignment="Center" HorizontalAlignment="Center" IsChecked="{Binding Status}" Width="100" Height="35">
                                <ToggleButton.Resources>
                                    <Image x:Key="OnImage" Source="C:\ON.jpg" />
                                    <Image x:Key="OffImage" Source="C:\OFF.jpg" />
                                </ToggleButton.Resources>
                                <ToggleButton.Style>
                                    <Style TargetType="ToggleButton">
                                        <Style.Triggers>
                                            <Trigger Property="IsChecked" Value="True">
                                                <Setter Property="Content" Value="{StaticResource OnImage}">
                                                </Setter>
                                            </Trigger>
                                            <Trigger Property="IsChecked" Value="False">
                                                <Setter Property="Content" Value="{StaticResource OffImage}">
                                                </Setter>
                                            </Trigger>
                                        </Style.Triggers>
                                    </Style>
                                </ToggleButton.Style>
                            </ToggleButton>
