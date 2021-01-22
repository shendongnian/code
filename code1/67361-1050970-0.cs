    <Button>
		<Button.Resources>
			<CheckBox x:Key="Local_MouseOverContent"
					  Content="Mouse is over" />
		</Button.Resources>
		<Button.Style>
			<Style TargetType="{x:Type Button}">
				<Setter Property="Content"
						Value="No mouse over" />
				<Style.Triggers>
					<Trigger Property="IsMouseOver"
							 Value="True">
						<Setter Property="Content" Value="{StaticResource Local_MouseOverContent}" />
					</Trigger>
				</Style.Triggers>
			</Style>
		</Button.Style>
	</Button>
    <Button>
		<Button.Style>
			<Style TargetType="{x:Type Button}">
				<Setter Property="Content"
						Value="No mouse over" />
				<Style.Triggers>
					<Trigger Property="IsMouseOver"
							 Value="True">
						<Setter Property="ContentTemplate">
							<Setter.Value>
								<DataTemplate DataType="Button">
									<CheckBox Content="Mouse is over" />
								</DataTemplate>
							</Setter.Value>
						</Setter>
					</Trigger>
				</Style.Triggers>
			</Style>
		</Button.Style>
	</Button>
