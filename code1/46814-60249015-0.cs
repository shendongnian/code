    <ListView ItemsSource="{Binding SelectedTrack}" SelectedItem="{Binding SelectedTrack}" >
        <i:Interaction.Triggers>
             <i:EventTrigger EventName="MouseDoubleClick">
                  <i:InvokeCommandAction Command="{Binding SelectTrackCommand}"/>
             </i:EventTrigger>
        </i:Interaction.Triggers>
        ...........
        ...........
    </ListView>
