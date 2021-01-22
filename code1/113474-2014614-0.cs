    <UserControl>
    <Grid  x:Name="ResizeGrid"
           MouseEnter="Plugin_MouseEnter"
           MouseLeave="Plugin_MouseLeave">
        <Grid.RowDefinitions>
            <RowDefinition Height="20" />
            <RowDefinition Height="*" />
            <RowDefinition Height="5" />
        </Grid.RowDefinitions>
        
        <Border x:Name="border"
                BorderBrush="Black"
                BorderThickness="2"
                Padding="0"
                Margin="-1,-1,-1,-1">
        </Border>
        <Grid x:Name="grid"
              Grid.Row="0">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*" />
                <ColumnDefinition Width=".05*" />
            </Grid.ColumnDefinitions>
            <Thumb HorizontalAlignment="Stretch"
                   Background="Green"
                   DragDelta="Thumb_DragDelta"
                   />
            <Button Content="X"
                    HorizontalAlignment="Right"
                    Grid.Column="1"
                    cmd:Click.Command="{Binding CloseCommand}"
                    cmd:Click.CommandParameter="{Binding PluginID}" />
        </Grid>
        <Border BorderBrush="Black"
                BorderThickness="2"
                Margin="0"
                VerticalAlignment="Center"
                HorizontalAlignment="Center"
                Grid.Row="1">
            <tk:Viewbox Stretch="Uniform"
                        StretchDirection="Both">
                <ContentControl rgn:RegionManager.RegionName="PluginViewRegion" />
            </tk:Viewbox>
        </Border>
        <Thumb x:Name="SizeGrip"
               Grid.Row="1"
               VerticalAlignment="Bottom"
               HorizontalAlignment="Right"
               Width="10"
               Height="10"
               Margin="0,0,-7,-7"
               Style="{StaticResource SizeGrip}"
               DragDelta="SizeGrip_DragDelta"
               DragStarted="SizeGrip_DragStarted"
               DragCompleted="SizeGrip_DragCompleted" />
    </Grid>
    </UserControl>  
---
 
    public class WorkspaceItemViewModel : INotifyPropertyChanged
    {
        private IWorkspaceManager workspaceManager;
        private IRegionManager regionManager;
        private Guid pluginID;
        public WorkspaceItemViewModel(IWorkspaceManager workspaceManager, IRegionManager regionManager)
        {
            this.workspaceManager = workspaceManager;
            this.regionManager = regionManager;
        }
        public DelegateCommand<object> CloseCommand 
        {
            get
            {
                return workspaceManager.CloseCommand;
            }    
        }
        public DelegateCommand<object> SelectCommand
        {
            get
            {
                return workspaceManager.SelectCommand;
            }
        }
        public object CloseCommandParameter
        {
            get
            {
                return this;
            }
        }
        public Guid PluginID
        {
            get
            {
                return this.pluginID;
            }
            set
            {
                this.pluginID = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("PluginID"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }  
