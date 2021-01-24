    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="auto" />
            <RowDefinition Height="*" />
            <RowDefinition Height="auto" />
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        
        <!-- Some XAML for the grid content -->
    
        <!-- Here, Frame covers all the possible space defined using RowSpan/ColumnSpan -->
        <Frame Grid.RowSpan="3" Grid.ColumnSpan="2" IsVisible="{Binding IsBusy}" BackgroundColor="LightGray">
           <Label VerticalOptions="Center" HorizontalOptions="Center" Text="Loading Samples..." />
        </Frame>
    </Grid>
