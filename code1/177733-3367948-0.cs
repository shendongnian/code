    <Window x:Class="StackOverflowTests.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    	xmlns:sys="clr-namespace:System;assembly=mscorlib"
    	xmlns:local="clr-namespace:StackOverflowTests"
        Title="Window1"
    	x:Name="window1"
    	Width="300"
    	Height="300">
    	<Window.Resources>
    
    		<ControlTemplate x:Key="invisibleButtonTreeViewItemTemplate" TargetType="TreeViewItem" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" xmlns:s="clr-namespace:System;assembly=mscorlib" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    			<Grid>
    				<Grid.ColumnDefinitions>
    					<ColumnDefinition Width="Auto" MinWidth="19" />
    					<ColumnDefinition Width="Auto" />
    					<ColumnDefinition Width="*" />
    				</Grid.ColumnDefinitions>
    				<Grid.RowDefinitions>
    					<RowDefinition Height="Auto" />
    					<RowDefinition />
    				</Grid.RowDefinitions>
    				<!-- Make the ToggleButton invisible -->
    				<ToggleButton IsChecked="False" Visibility="Hidden" ClickMode="Press" Name="Expander" />
    				<Border BorderThickness="{TemplateBinding Border.BorderThickness}" Padding="{TemplateBinding Control.Padding}" BorderBrush="{TemplateBinding Border.BorderBrush}" Background="{TemplateBinding Panel.Background}" Name="Bd" SnapsToDevicePixels="True" Grid.Column="1">
    					<ContentPresenter Content="{TemplateBinding HeaderedContentControl.Header}" ContentTemplate="{TemplateBinding HeaderedContentControl.HeaderTemplate}" ContentStringFormat="{TemplateBinding HeaderedItemsControl.HeaderStringFormat}" ContentSource="Header" Name="PART_Header" HorizontalAlignment="{TemplateBinding Control.HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding UIElement.SnapsToDevicePixels}" />
    				</Border>
    				<ItemsPresenter Name="ItemsHost" Grid.Column="1" Grid.Row="1" Grid.ColumnSpan="2" />
    			</Grid>
    			<ControlTemplate.Triggers>
    				<Trigger Property="TreeViewItem.IsExpanded">
    					<Setter Property="UIElement.Visibility" TargetName="ItemsHost">
    						<Setter.Value>
    							<x:Static Member="Visibility.Collapsed" />
    						</Setter.Value>
    					</Setter>
    					<Trigger.Value>
    						<s:Boolean>False</s:Boolean>
    					</Trigger.Value>
    				</Trigger>
    				<Trigger Property="ItemsControl.HasItems">
    					<Setter Property="UIElement.Visibility" TargetName="Expander">
    						<Setter.Value>
    							<x:Static Member="Visibility.Hidden" />
    						</Setter.Value>
    					</Setter>
    					<Trigger.Value>
    						<s:Boolean>False</s:Boolean>
    					</Trigger.Value>
    				</Trigger>
    				<Trigger Property="TreeViewItem.IsSelected">
    					<Setter Property="Panel.Background" TargetName="Bd">
    						<Setter.Value>
    							<DynamicResource ResourceKey="{x:Static SystemColors.HighlightBrushKey}" />
    						</Setter.Value>
    					</Setter>
    					<Setter Property="TextElement.Foreground">
    						<Setter.Value>
    							<DynamicResource ResourceKey="{x:Static SystemColors.HighlightTextBrushKey}" />
    						</Setter.Value>
    					</Setter>
    					<Trigger.Value>
    						<s:Boolean>True</s:Boolean>
    					</Trigger.Value>
    				</Trigger>
    				<MultiTrigger>
    					<MultiTrigger.Conditions>
    						<Condition Property="TreeViewItem.IsSelected">
    							<Condition.Value>
    								<s:Boolean>True</s:Boolean>
    							</Condition.Value>
    						</Condition>
    						<Condition Property="Selector.IsSelectionActive">
    							<Condition.Value>
    								<s:Boolean>False</s:Boolean>
    							</Condition.Value>
    						</Condition>
    					</MultiTrigger.Conditions>
    					<Setter Property="Panel.Background" TargetName="Bd">
    						<Setter.Value>
    							<DynamicResource ResourceKey="{x:Static SystemColors.ControlBrushKey}" />
    						</Setter.Value>
    					</Setter>
    					<Setter Property="TextElement.Foreground">
    						<Setter.Value>
    							<DynamicResource ResourceKey="{x:Static SystemColors.ControlTextBrushKey}" />
    						</Setter.Value>
    					</Setter>
    				</MultiTrigger>
    				<Trigger Property="UIElement.IsEnabled">
    					<Setter Property="TextElement.Foreground">
    						<Setter.Value>
    							<DynamicResource ResourceKey="{x:Static SystemColors.GrayTextBrushKey}" />
    						</Setter.Value>
    					</Setter>
    					<Trigger.Value>
    						<s:Boolean>False</s:Boolean>
    					</Trigger.Value>
    				</Trigger>
    			</ControlTemplate.Triggers>
    		</ControlTemplate>
    
    		<Style TargetType="{x:Type TreeViewItem}">
    			<Setter Property="Template" Value="{StaticResource invisibleButtonTreeViewItemTemplate}" />
    		</Style>
    		
    	</Window.Resources>
    	<TreeView>
    		<TreeViewItem Header="Item 1" IsExpanded="True">
    			<TreeViewItem Header="Item 1.1" IsExpanded="True" />
    			<TreeViewItem Header="Item 1.2" IsExpanded="True">
    				<TreeViewItem Header="Item 1.2.1" IsExpanded="True" />
    			</TreeViewItem>
    		</TreeViewItem>
    		<TreeViewItem Header="Item 2" IsExpanded="True">
    			<TreeViewItem Header="Item 2.1" IsExpanded="True" />
    		</TreeViewItem>
    	</TreeView>
    </Window>
