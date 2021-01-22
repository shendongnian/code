    <TabControl>
    	<TabControl.ItemsSource>
    		<CompositeCollection>
			<CollectionContainer Collection="{StaticResource items}" />
    			<TabItem>
				<TabItem.Template>
    					<ControlTemplate>
    						<Border Name="PART_Header" Margin="4,0,1,1">    								
    							<Button Click="AddTicket">Add Ticket</Button>
						</Border>
					</ControlTemplate>
    				</TabItem.Template>
    			</TabItem>
    		</CompositeCollection>
    	</TabControl.ItemsSource>
    </TabControl>
