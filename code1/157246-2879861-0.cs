    <Grid>
      <Grid.Resources>
          <DataTemplate x:Key=TopicDataTemplate>
              <Expander Header="{Binding Path=TopicName}" >
                  <Expander.Content>
                      <ListBox ItemTemplate={StaticResource TopicContentDataTemplate} />
                  </Expander.Content>
              </Expander>
          </DataTemplate>
          <DataTemplate x:key=TopicContentDataTemplate>
              <Label 
                  Content="{Binding Path=(ItemName)}" 
                  Width="120px" 
                  Height="32px" 
                  Foreground="Black" />
          </DataTemplate>
      </Grid.Resources>
        
      <ListBox 
         Grid.Column="0" 
         Name="lbTopics" 
         ItemsSource="{Binding}" 
         ItemTemplate={StaticResource TopicDataTemplate} />
    </Grid>
