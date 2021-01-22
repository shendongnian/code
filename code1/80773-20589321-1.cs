    <Window x:Class="WpfTestbed.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:sys="clr-namespace:System;assembly=mscorlib">
      <Grid>
        <DockPanel HorizontalAlignment="Stretch" VerticalAlignment="Stretch" LastChildFill="True">
    
          <GridViewRowPresenter Columns="{Binding ElementName=ListViewGridView, Path=Columns}" DockPanel.Dock="Bottom" Margin="4,5,0,5">
            <GridViewRowPresenter.Content>
              <sys:DateTime>2005/2/1</sys:DateTime>
            </GridViewRowPresenter.Content>
          </GridViewRowPresenter>
    
          <ListView SelectionMode="Single" ScrollViewer.HorizontalScrollBarVisibility="Disabled">
            <ListView.View>
              <GridView x:Name="ListViewGridView">
                <GridViewColumn Header="Date" />
                <GridViewColumn Header="Day Of Week" DisplayMemberBinding="{Binding DayOfWeek}" />
                <GridViewColumn Header="Year" DisplayMemberBinding="{Binding Year}" />
              </GridView>
            </ListView.View>
    
            <sys:DateTime>1/2/3</sys:DateTime>
            <sys:DateTime>4/5/6</sys:DateTime>
            <sys:DateTime>7/8/9</sys:DateTime>
            <sys:DateTime>10/11/12</sys:DateTime>
            <sys:DateTime>1/2/3</sys:DateTime>
            <sys:DateTime>4/5/6</sys:DateTime>
            <sys:DateTime>7/8/9</sys:DateTime>
            <sys:DateTime>10/11/12</sys:DateTime>
            <sys:DateTime>1/2/3</sys:DateTime>
            <sys:DateTime>4/5/6</sys:DateTime>
            <sys:DateTime>7/8/9</sys:DateTime>
            <sys:DateTime>10/11/12</sys:DateTime>
            <sys:DateTime>1/2/3</sys:DateTime>
            <sys:DateTime>4/5/6</sys:DateTime>
            <sys:DateTime>7/8/9</sys:DateTime>
            <sys:DateTime>10/11/12</sys:DateTime>
          </ListView>
    
        </DockPanel>
      </Grid>
    </Window>
