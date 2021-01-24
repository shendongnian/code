    <Entry Text="{Binding Text}">
        <Entry.Behaviors>
            <behaviors:EventToCommandBehavior EventName="Focused"
                                              Command="{Binding FocusedCommand}" />
        </Entry.Behaviors>
    </Entry>
