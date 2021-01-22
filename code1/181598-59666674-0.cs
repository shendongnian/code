        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Tab:
                    // Execute your command. Something similar to:
                    ((YourDataContextType)DataContext).MyCommand.Execute(parameter:null);
                    break;
            }
        }
