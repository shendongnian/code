    public static readonly DependencyProperty IsCameraCheckedProperty = DependencyProperty.Register(nameof(IsCameraChecked), typeof(bool), typeof(TWDebugRecorder), new PropertyMetadata(false, CameraCheckedChanged));
    
    private static void CameraCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
    	_isConnected = value;
    	OnPropertyChanged();
    }
