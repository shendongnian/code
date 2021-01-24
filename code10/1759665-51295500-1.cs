	<MenuItem>
			<i:Interaction.Triggers xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity">
				<i:EventTrigger EventName="OnSubmenuOpened">
					<cmd:EventToCommand Command="{Binding SubmenuOpenedCommand}"  />
				</i:EventTrigger>
			</i:Interaction.Triggers>
