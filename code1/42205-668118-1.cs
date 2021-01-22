    private bool isRulerWidthValid = false;
    protected override Size MeasureOverride(Size available)
    {
        ... // other code for measuring
        if (!isRulerWidthValid)
        { 
            Dispatcher.BeginInvoke(new Action(CalculateRulerSize));
            ... // return some temporary value here
        }
        ... // do your normal measure logic
    }
    private void CalculateRulerSize(Size available)
    {
        Size elemSize = new Size(double.PositiveInfinity, RowHeight);
        m_inputWidth = 0.0;
        foreach (MapElementViewModel elem in m_vm.InputElements)
        {
           ruler.DataContext = elem;
           ruler.Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.DataBind);
           ruler.Measure(elemSize);
           m_inputWidth = Math.Max(m_inputWidth, ruler.DesiredSize.Width);
        }
        // invalidate measure again, as we now have a value for m_inputwidth
        isRulerWidthValid = true;
        InvalidateMeasure();
    }
