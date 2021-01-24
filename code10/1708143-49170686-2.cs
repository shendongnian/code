            <ComboBox SelectedItem="{Binding SelectedFooItem, Mode=TwoWay}" 
      IsSynchronizedWithCurrentItem="False"
      DisplayMemberPath="Name" >
                <ComboBox.ItemsSource>
                        <CompositeCollection>
                            <CollectionContainer Collection="{Binding Source={StaticResource FooItemsCollection}}" />
                            <ComboBoxItem>
                                <TextBlock Content="NotAFoo"></Button>
                            </ComboBoxItem>
                        </CompositeCollection>
                </ComboBox.ItemsSource>
                <ComboBox.Style>
                    <Style TargetType="{x:Type ComboBox}">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding Path=SelectedItem.Content}" Value="NotAFoo">
                                <Setter Property="SelectedItem" Value="{x:Null}" />
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </ComboBox.Style>
            </ComboBox>
