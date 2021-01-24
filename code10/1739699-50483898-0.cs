			<ItemsControl ItemsSource="{Binding Datasource1}">
				<ItemsControl.ItemsPanel>
				  <ItemsPanelTemplate>
					<StackPanel >
					</StackPanel>
				  </ItemsPanelTemplate>
				</ItemsControl.ItemsPanel>
				<ItemsControl.ItemTemplate>
				  <DataTemplate>
					  <Expander Header="Header1"  >
									<Expander.HeaderTemplate>
										<DataTemplate>
												<StackPanel>                                       
												</StackPanel>
										</DataTemplate>
									</Expander.HeaderTemplate>
									<Grid>
						<ItemsControl ItemsSource="{Binding Datasource2}">
						  <ItemsControl.ItemsPanel>
							<ItemsPanelTemplate>
							  <StackPanel></StackPanel>
							</ItemsPanelTemplate>
						  </ItemsControl.ItemsPanel>
						  <ItemsControl.ItemTemplate>
							<DataTemplate>
								<Expander Header="Header2">
									<Expander.HeaderTemplate>
										<DataTemplate>
											<StackPanel>
											</StackPanel>
										</DataTemplate>
									</Expander.HeaderTemplate>
									<DataGrid  ItemsSource="{Binding Datasource3to8}" AutoGenerateColumns="False" >
								  <DataGrid.Columns>
									<DataGridTextColumn Header="Test"
														Width="Auto"
														Binding="{Binding Datasource3}" />
									<DataGridTextColumn Header="Test"
														Width="Auto"
														Binding="{Binding Datasource4}" />
									<DataGridTextColumn Header="Test"
														Width="Auto"
														Binding="{Binding Datasource5}" />
									<DataGridTextColumn Header="Test"
														Width="Auto"
														Binding="{Binding Datasource6}" />
									<DataGridTextColumn Header="Test"
														Width="Auto"
														Binding="{Binding Datasource7}" />
								  <DataGridTextColumn Header="Test"
														Width="Auto"
														Binding="{Binding Datasource8}" />
								  </DataGrid.Columns>
								 </DataGrid>
							  </Expander>
							</DataTemplate>
						  </ItemsControl.ItemTemplate>
						</ItemsControl>
					  </Grid>
					</Expander>
				  </DataTemplate>
				</ItemsControl.ItemTemplate>
			  </ItemsControl>
