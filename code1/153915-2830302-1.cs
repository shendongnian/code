    <TabItem Header="Finished">
				<TabItem.Resources>
					<ResourceDictionary>
							<ResourceDictionary.MergedDictionaries>
								<ResourceDictionary Source="AnimeExpander.xaml"/>
							</ResourceDictionary.MergedDictionaries>
							
							<DataTemplate x:Key="EpisodeItem">
								<DockPanel Margin="30,3">
									<TextBlock Text="{Binding Title}" DockPanel.Dock="Left" />
									<WrapPanel Margin="10,0" DockPanel.Dock="Right">
										<TextBlock Text="Finished at: " />
										<TextBlock Text="{Binding TimeAdded}" />
									</WrapPanel>
								</DockPanel>
							</DataTemplate>
							
							<DataTemplate x:Key="AnimeItem">
								<DockPanel Margin="5,10">
									<Image Height="75" Width="Auto" Source="{Binding ImagePath}" DockPanel.Dock="Left" VerticalAlignment="Top"/> 
									<Expander Template="{StaticResource AnimeExpanderControlTemplate}" >
										<Expander.Header>
											<TextBlock FontWeight="Bold" Text="{Binding AnimeTitle}" />
										</Expander.Header>
										
											<ListView ItemsSource="{Binding Episodes}" ItemTemplate="{StaticResource EpisodeItem}" BorderThickness="0,0,0,0" />
										
									</Expander>
								</DockPanel>							
							</DataTemplate>							
						</ResourceDictionary>			
				</TabItem.Resources>
				
				<ListView Name="finishedView" ItemsSource="{Binding UploadedAnime, diagnostics:PresentationTraceSources.TraceLevel=High}" ItemTemplate="{StaticResource AnimeItem}" />					
    </TabItem>
