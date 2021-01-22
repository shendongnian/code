            if (e.StagingItem.Input is System.Windows.Input.TextCompositionEventArgs)
            {
                if (!String.IsNullOrEmpty((e.StagingItem.Input as System.Windows.Input.TextCompositionEventArgs).Text))
                {
                    Char c = (e.StagingItem.Input as System.Windows.Input.TextCompositionEventArgs).Text[0];
                }
            }
