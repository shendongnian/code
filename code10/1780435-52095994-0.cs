    <ItemsControl ItemsSource="{StaticResource userDataCollection}">
       <!-- Changing Orientation of VirtualizingStackPanel -->
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <VirtualizingStackPanel Orientation="Horizontal"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
    
       <!-- To scroll horizontally -->
       <ItemsControl.Template>
           <ControlTemplate TargetType="ItemsControl">
               <ScrollViewer HorizontalScrollBarVisibility="Visible">
                   <ItemsPresenter/>
               </ScrollViewer>
           </ControlTemplate>
       </ItemsControl.Template>
    
       <!-- Template for each card-->
       <ItemsControl.ItemTemplate>
    		<DataTemplate>
    			<Grid>
    				<Grid.ColumnDefinitions>
    					<ColumnDefinition Width="220"/>
    					<ColumnDefinition Width="220"/>
    					<ColumnDefinition Width="220"/>
    					<ColumnDefinition Width="220"/>
    				</Grid.ColumnDefinitions>    
    				<TextBlock Grid.Column="0" Text="{Binding Name}"/>
    				<TextBlock Grid.Column="1" Text="{Binding PayDate}"/>
    				<TextBlock Grid.Column="1" Text="{Binding NumberOfItems}"/>    
    			</Grid>
    		</DataTemplate>
    	</ItemsControl.ItemTemplate>
    </ItemsControl>
