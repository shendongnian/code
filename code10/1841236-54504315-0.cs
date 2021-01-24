    <Grid>
      <Grid.ColumnDefinitions>
          <ColumnDefinition Width="*"/>
          <ColumnDefinition Width="*"/>
      </Grid.ColumnDefinitions>
      <Label Text = "{Binding @something}" GridRow = 0 GridColumn = 0/>
      <Grid.GestureRecognizers>
          <TapGestureRecognizer Command="{Binding TapCommand}"/>
      </Grid.GestureRecognizers>
    </Grid>
