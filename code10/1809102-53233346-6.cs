                        <ComboBox.ItemTemplate>
                            <DataTemplate>
                                <StackPanel Orientation="Horizontal">
                                    <CheckBox Width="200" Content={Binding}>
                                      <CheckBox.IsChecked>
                                        <MultiBinding Converter="{StaticResource TextInListTrueFalseConverter}" >
                                            <Binding ElementName="cbb_Keywords" Path="DataContext.KeywordsForTextbox"></Binding>
                                            <Binding RelativeSource="{RelativeSource Self}" Path="Content"></Binding>
                                        </MultiBinding>
                                      </CheckBox.IsChecked>
                                    </CheckBox>
                                </StackPanel>
                            </DataTemplate>
                        </ComboBox.ItemTemplate>
