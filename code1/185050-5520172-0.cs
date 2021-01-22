    <Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:sys="clr-namespace:System;assembly=mscorlib">
      <Grid Background="Transparent">
        <Grid.Resources>
            <x:Array Type="{x:Type sys:Object}" x:Key="extensions">
                <Separator />
                <MenuItem Header="Extension MenuItem 1" />
                <MenuItem Header="Extension MenuItem 2" />
                <MenuItem Header="Extension MenuItem 3" />
            </x:Array>
        </Grid.Resources>
        <Grid.ContextMenu>
            <ContextMenu>
                <ContextMenu.ItemsSource>
                    <CompositeCollection>
                        <MenuItem Header="Standard MenuItem 1" />
                        <MenuItem Header="Standard MenuItem 2" />
                        <MenuItem Header="Standard MenuItem 3" />
                        <CollectionContainer Collection="{StaticResource extensions}" />
                    </CompositeCollection>
                </ContextMenu.ItemsSource>
            </ContextMenu>
        </Grid.ContextMenu>
      </Grid>
    </Window>
        
