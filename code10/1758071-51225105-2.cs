    <DataGridTextColumn Header="{DynamicResource hour}" Binding="{Binding Result}">
    	<DataGridTextColumn.CellStyle>
    	  <Style TargetType="{x:Type DataGridCell}" BasedOn="{StaticResource MaterialDesignDataGridCell}">
    		<Style.Triggers>
    			<DataTrigger Binding="{Binding ResultChanged}" Value="True" >
    				<DataTrigger.EnterActions>
    					<BeginStoryboard>
    						<Storyboard>
    							<Storyboard x:Name="Blink" 
    										AutoReverse="True" 
    										RepeatBehavior="5x">
    								<ColorAnimationUsingKeyFrames BeginTime="00:00:00"
    									Storyboard.TargetProperty="(Background).(SolidColorBrush.Color)">
    									<EasingColorKeyFrame KeyTime="00:00:01" 
    														 Value="Orange" />
    								</ColorAnimationUsingKeyFrames>
    								<ColorAnimationUsingKeyFrames 
    									BeginTime="00:00:00"
    									Storyboard.TargetProperty="(Foreground).(SolidColorBrush.Color)">
    									<EasingColorKeyFrame KeyTime="00:00:01" 
    														 Value="Black" />
    								</ColorAnimationUsingKeyFrames>
    							</Storyboard>
    							<Storyboard AutoReverse="False">
    								<ColorAnimationUsingKeyFrames BeginTime="00:00:10" Storyboard.TargetProperty="(Background).(SolidColorBrush.Color)">
    									<EasingColorKeyFrame KeyTime="00:00:01" Value="Orange" />
    								</ColorAnimationUsingKeyFrames>
    							</Storyboard>
    						</Storyboard>
    					</BeginStoryboard>
    				</DataTrigger.EnterActions>
    			</DataTrigger>
    		</Style.Triggers>
    	  </Style>
    	</DataGridTextColumn.CellStyle>
    </DataGridTextColumn>
