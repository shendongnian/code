     <TextBox Text="{Binding SomeText, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
        	<TextBox.Style>
        		<Style>
        			<Style.Triggers>
        				<DataTrigger Binding="{Binding SomeTextIsFocused, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Value="True">
        					<Setter Property="FocusManager.FocusedElement" Value="{Binding RelativeSource={RelativeSource Self}}" />
        				</DataTrigger>
        			</Style.Triggers>
        		</Style>
        	</TextBox.Style>
        </TextBox>
