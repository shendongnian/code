       <ItemsControl ItemsSource="{Binding Items}">
            <ItemsControl.LayoutTransform>
                <RotateTransform Angle="270"/>
            </ItemsControl.LayoutTransform>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <ComboBox ItemsSource="{Binding SubItems}"
                              >
                        <ComboBox.Resources>
                            <Style TargetType="ItemsPresenter">
                                <Setter Property="LayoutTransform">
                                    <Setter.Value>
                                        <RotateTransform Angle="-270" />
                                    </Setter.Value>
                                </Setter>
                            </Style>
                        </ComboBox.Resources>
                    </ComboBox>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
