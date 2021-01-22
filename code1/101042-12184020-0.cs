    //1.Create Attached Property
    public static class DataGridCellAttachedProperties
    {
        //Register new attached property
        public static readonly DependencyProperty IsSingleClickEditModeProperty =
            DependencyProperty.RegisterAttached("IsSingleClickEditMode", typeof(bool), typeof(DataGridCellAttachedProperties), new UIPropertyMetadata(false, OnPropertyIsSingleClickEditModeChanged));
        private static void OnPropertyIsSingleClickEditModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dataGridCell = d as DataGridCell;
            if (dataGridCell == null)
                return;
            var isSingleEditMode = GetIsSingleClickEditMode(d);
            var behaviors =  Interaction.GetBehaviors(d);
            var singleClickEditBehavior = behaviors.SingleOrDefault(x => x is SingleClickEditDataGridCellBehavior);
            
            if (singleClickEditBehavior != null && !isSingleEditMode)
                behaviors.Remove(singleClickEditBehavior);
            else if (singleClickEditBehavior == null && isSingleEditMode)
            {
                singleClickEditBehavior = new SingleClickEditDataGridCellBehavior();
                behaviors.Add(singleClickEditBehavior);
            }
        }
        public static bool GetIsSingleClickEditMode(DependencyObject obj)
        {
            return (bool) obj.GetValue(IsSingleClickEditModeProperty);
        }
        public static void SetIsSingleClickEditMode(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSingleClickEditModeProperty, value);
        }
    }
    //2. Create Behavior
    public class SingleClickEditDataGridCellBehavior:Behavior<DataGridCell>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewMouseLeftButtonDown += DataGridCellPreviewMouseLeftButtonDown;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewMouseLeftButtonDown += DataGridCellPreviewMouseLeftButtonDown;
        }
        void DataGridCellPreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
             DataGridCell cell = sender as DataGridCell;
            if (cell != null && !cell.IsEditing && !cell.IsReadOnly)
            {
                if (!cell.IsFocused)
                {
                    cell.Focus();
                }
                DataGrid dataGrid = LogicalTreeWalker.FindParentOfType<DataGrid>(cell); //FindVisualParent<DataGrid>(cell);
                if (dataGrid != null)
                {
                    if (dataGrid.SelectionUnit != DataGridSelectionUnit.FullRow)
                    {
                        if (!cell.IsSelected)
                            cell.IsSelected = true;
                    }
                    else
                    {
                        DataGridRow row =  LogicalTreeWalker.FindParentOfType<DataGridRow>(cell); //FindVisualParent<DataGridRow>(cell);
                        if (row != null && !row.IsSelected)
                        {
                            row.IsSelected = true;
                        }
                    }
                }
            }
        }    
    }
    <!-3.Create a Style and set the attached property-->
            <Style TargetType="{x:Type DataGridCell}" BasedOn="{StaticResource {x:Type DataGridCell}}" x:Key="DeleteSensitiveCell">
                <Setter Property="Behaviors:DataGridCellAttachedProperties.IsSingleClickEditMode" Value="True"/>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Path=IsDeleted}" Value="True">
                        <Setter Property="Background" Value="Gray"/>
                        <Setter Property="IsEnabled" Value="False"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
