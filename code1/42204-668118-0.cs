    foreach (MapElementViewModel elem in m_vm.InputElements)
    {
       ruler.DataContext = elem;
       ruler.Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.DataBind);
       ruler.Measure(elemSize);
       m_inputWidth = Math.Max(m_inputWidth, ruler.DesiredSize.Width);
    }
