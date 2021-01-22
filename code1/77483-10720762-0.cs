     private void PutFocusOnControl(Control element)
            {
                if (element != null)
                    Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input,
                        (System.Threading.ThreadStart)delegate
                        {
                            element.Focus();
                        });
            }
