for (int i = 1; i < 4; i++)
{
    Dispatcher.BeginInvoke(DispatcherPriority.SystemIdle, () => { Grid.SetColumn(lblUno, i) } );
    Thread.Sleep(1000);
}
