                                <ItemsControl ItemsSource="{Binding CheckBoxTemplates}">
                                    <ItemsControl.ItemsPanel>
                                        <ItemsPanelTemplate>
                                            <StackPanel Orientation="Vertical" Margin="40,0,0,0"></StackPanel>
                                        </ItemsPanelTemplate>
                                    </ItemsControl.ItemsPanel>
                                    <ItemsControl.ItemTemplate>
                                        <DataTemplate>
                                        <CheckBox Content="{Binding Path=Content}" >
                                            <CheckBox.Style>
                                                <Style TargetType="CheckBox">
                                                    <Setter Property="IsChecked">
                                                        <Setter.Value>
                                                            <MultiBinding Converter="{StaticResource FlagToBoolConverter}">
                                                                <Binding Path="MyEnumProperty" Mode="TwoWay" UpdateSourceTrigger="PropertyChanged"></Binding>
                                                                <Binding Path="MyEnumPropertyMask"></Binding>
                                                            </MultiBinding>
                                                        </Setter.Value>
                                                    </Setter>
                                                </Style>
                                            </CheckBox.Style>
                                        </CheckBox>
                                        </DataTemplate>
                                    </ItemsControl.ItemTemplate>
                                </ItemsControl>
                                
  
  
