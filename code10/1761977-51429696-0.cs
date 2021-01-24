    using System.Windows;
    using System.Windows.Input;
    public partial class YourWindow : Window
    {
        MouseCapturePreview MouseCaptureHandler;
        //(...)
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MouseCaptureHandler = new MouseCapturePreview(this);
            //(...)
        }
        public class MouseCapturePreview
        {
            public MouseCapturePreview(Window element)
            {
                InputManager.Current.PreProcessInput += (s, e) => {
                    if (e.StagingItem.Input is MouseButtonEventArgs)
                        Handler(s, (MouseButtonEventArgs)e.StagingItem.Input);
                };
                
                void Handler(object sender, MouseButtonEventArgs e)
                {
                    Console.WriteLine("Event Received");
                    if (e.LeftButton == MouseButtonState.Pressed) {
                        Console.WriteLine("Mouse Released");
                        element.ReleaseMouseCapture();
                        Mouse.Capture(element);
                        if (!element.RestoreBounds.Contains(element.PointToScreen(e.GetPosition(element))))
                        {
                            Console.WriteLine("Clicked outside");
                            MessageBox.Show("You clicked outside, time to close.");
                            Application.Current.Shutdown();
                        }
                    } else {
                        Console.WriteLine("Mouse Captured");
                        element.CaptureMouse();
                    }
                }
            }
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("Activated");
            this.CaptureMouse();
        }
    }
