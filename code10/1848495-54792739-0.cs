    <ListView x:Name="_listView" 
    	Height="365" 
    	Background="{DynamicResource {x:Static SystemColors.ControlBrushKey}}">
    	<ListView.ItemContainerStyle>
    		<Style TargetType="{x:Type ListViewItem}">
    			<Setter Property="BorderBrush" Value="LightGray" />
    			<Setter Property="BorderThickness" Value="0,0,1,1" />
    		</Style>
    	</ListView.ItemContainerStyle>
    	<ListView.View>
    		<GridView>
    			<GridView.Columns>
    				<GridViewColumn>
    					<GridViewColumn.CellTemplate>
    						<DataTemplate>
    						   <CheckBox Content="{Binding DocNo}" IsChecked="{Binding Checked, Mode=OneWay}"/>  
    					   </DataTemplate>
    					</GridViewColumn.CellTemplate>
    				</GridViewColumn>
    				<GridViewColumn DisplayMemberBinding="{Binding DocNo}" Header="Request Number" />
    				<GridViewColumn DisplayMemberBinding="{Binding QtyReq}" Header="Requested to UL" />
    				<GridViewColumn DisplayMemberBinding="{Binding Price}" Header="Price" />
    				<GridViewColumn DisplayMemberBinding="{Binding Date}" Header="Date" />
    				<GridViewColumn DisplayMemberBinding="{Binding Status}" Header="Status" />
    				<GridViewColumn DisplayMemberBinding="{Binding Confirm}" Header="Received" />
    			</GridView.Columns>
    		</GridView>
    	</ListView.View>
    </ListView>
