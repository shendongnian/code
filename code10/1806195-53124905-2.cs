    <TreeView ItemSource="{Binding Items}" >
      <TreeView.Resources>          
          <Style TargetType="TreeViewItem">
             <Setter Property="IsExpanded" Value="{Binding IsExpanded, Mode=TwoWay}" />
             <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}" />
             <Style.Triggers>
                 <Trigger Property="IsSelected" Value="True">
                     <Setter Property="Background" Value="Blue" />
                     <Setter Property="Foreground" Value="White" />
                 </Trigger>
             </Style.Triggers>
         </Style>
      </TreeView.Resources>
    </TreeView>
