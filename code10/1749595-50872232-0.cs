    <ListView.ItemTemplate>
      <DataTemplate>
         <Button BorderBrush="Transparent" Background="Transparent" Focusable="False">
            <i:Interaction.Triggers>
                    <i:EventTrigger EventName="Click">
                        <i:InvokeCommandAction Command="{Binding DataContext.ClickCommand, ElementName=ListViewName}" CommandParameter="{Binding}"/>
                    </i:EventTrigger>
            </i:Interaction.Triggers>
            <!-- YOUR TEMPLATE HERE -->
          <Button.Template>
      </DataTemplate>
    </ListView.ItemTemplate>
