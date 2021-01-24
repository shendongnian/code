	<Image Grid.Row="1">
			<Image.Style>
				<Style TargetType="Image">
					<Setter Property="Visibility" Value="Visible" />
					<Style.Triggers>
						 <!-- Hide when Images is null -->
						<DataTrigger Binding="{Binding Images}" Value="{x:Null}">
							<Setter Property="Visibility" Value="Hidden" />
						</DataTrigger>
						 <!-- Hide when Images[0] is null -->
						<DataTrigger Binding="{Binding Images[0]}" Value="{x:Null}">
							<Setter Property="Visibility" Value="Hidden" />
						</DataTrigger>
					</Style.Triggers>
				</Style>
			</Image.Style>
		</Image>
