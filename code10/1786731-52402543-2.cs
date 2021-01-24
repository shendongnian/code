        private bool _mRestoreForDragMove;
        private void OnAppWindowWindowOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (_appWindowWindow.ResizeMode != ResizeMode.CanResize &&
                    _appWindowWindow.ResizeMode != ResizeMode.CanResizeWithGrip)
                {
                    return;
                }
                _appWindowWindow.WindowState = _appWindowWindow.WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized;
            }
            else
            {
                _mRestoreForDragMove = _appWindowWindow.WindowState == WindowState.Maximized;
                SafeDragMoveCall(e);
            }
        }
        private void SafeDragMoveCall(MouseEventArgs e)
        {
            Task.Delay(100).ContinueWith(_ =>
            {
                Dispatcher.BeginInvoke((Action)
                    delegate
                    {
                        if (Mouse.LeftButton == MouseButtonState.Pressed)
                        {
                            _appWindowWindow.DragMove();
                            RaiseEvent(new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, MouseButton.Left)
                            {
                                RoutedEvent = MouseLeftButtonUpEvent
                            });
                        }
                    });
            });
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_mRestoreForDragMove)
            {
                _mRestoreForDragMove = false;
                var point = PointToScreen(e.MouseDevice.GetPosition(this));
                _appWindowWindow.Left = point.X - (_appWindowWindow.RestoreBounds.Width * 0.5);
                _appWindowWindow.Top = point.Y;
                _appWindowWindow.WindowState = WindowState.Normal;
                _appWindowWindow.DragMove();
                SafeDragMoveCall(e);
            }
        }
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _mRestoreForDragMove = false;
        }
