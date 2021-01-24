    <ListView x:Name="listView" ItemsSource="{Binding Items}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <ViewCell>
                    <StackLayout Orientation="Horizontal">
                        <Label Text="{Binding ItemName}" />
                        <Label Text="Count:" />
                        <Label Text="{Binding Count}" />
                        <Button Text="+" Command="{Binding BtnClickPlusCommand}"  />
                        <Button Text="-" Command="{Binding BtnClickMinusCommand}"  />
                    </StackLayout>
                </ViewCell>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
