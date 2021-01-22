        private void NewApplicationCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Whatever logic you use to determine whether or not your
            // command is enabled.  I'm setting it to true for now so 
            // the command will always be enabled.
            e.CanExecute = true;
        }
        private void NewApplicationCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Console.WriteLine("New command executed");
        }
