    <ItemsControl ScrollViewer.HorizontalScrollBarVisibility="Disabled">
        <ItemsControl.Resources>
            <CollectionViewSource x:Key="cvs" Source="{Binding MyItems}" />
        </ItemsControl.Resources>
        <ItemsControl.ItemsSource>
            <CompositeCollection>
                <CollectionContainer Collection="{Binding Source={StaticResource cvs}}" />
                <!-- This should be inside items control: -->
                <TextBox />
            </CompositeCollection>
        </ItemsControl.ItemsSource>
        <!--  Make items wrap  -->
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <WrapPanel Orientation="Horizontal" />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <!--  Custom control  -->
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <local:CustomControl />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
