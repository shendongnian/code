    public class CustomControllerPlotBehavior : System.Windows.Interactivity.Behavior<Plot>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += OnLoaded;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= OnLoaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            CustomizeController(AssociatedObject.ActualController);
        }
        private void CustomizeController(IPlotController controller)
        {
            controller.UnbindAll();
            // actual changes to the controller
            controller.BindMouseDown(OxyMouseButton.Left, OxyModifierKeys.Shift, PlotCommands.ZoomRectangle);
            controller.BindMouseDown(OxyMouseButton.Left, OxyModifierKeys.Control, PlotCommands.PanAt);
            controller.BindMouseDown(OxyMouseButton.Left, PlotCommands.SnapTrack);
            controller.BindKeyDown(OxyKey.Home, PlotCommands.Reset);
            controller.BindMouseWheel(PlotCommands.ZoomWheel);
            controller.BindMouseWheel(OxyModifierKeys.Control, PlotCommands.ZoomWheelFine);
        }
    }
