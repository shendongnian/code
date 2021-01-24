    <TabControl ItemsSource="{Binding TabItems}" DisplayMemberPath="PropertyNameForTabHeader">
        <TabControl.Resources>
            <DataTemplate DataType="{x:Type viewModels:PricesViewModel}">
                <local:PricesControl/>
            </DataTemplate>
            <DataTemplate DataType="{x:Type viewModels:LicensesViewModel}">
                <local:LicenseControl/>
            </DataTemplate>
        </TabControl.Resources>
    </TabControl>
