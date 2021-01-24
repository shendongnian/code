    <StackLayout Orientation="Vertical">
        <Entry Placeholder="Email" Text="{Binding Email}">
            <Entry.Behaviors>
                <behaviors:EntryValidatorBehavior PropertyName="Email" />
            </Entry.Behaviors>
        </Entry>
        <Label Text="{Binding Errors[Email].FirstItem, Converter={StaticResource firstErrorToTextConverter}}"
               IsVisible="{Binding Errors[Email].Count, Converter={StaticResource errorToBoolConverter}}" />
        
        <Entry Placeholder="Password" Text="{Binding Password}">
            <Entry.Behaviors>
                <behaviors:EntryValidatorBehavior PropertyName="Password" />
            </Entry.Behaviors>
        </Entry>
        <Label Text="{Binding Errors[Password].FirstItem, Converter={StaticResource firstErrorToTextConverter}}"
               IsVisible="{Binding Errors[Password].Count, Converter={StaticResource errorToBoolConverter}}" />
    </StackLayout>
