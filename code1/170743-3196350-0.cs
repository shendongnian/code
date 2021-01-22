     private void CheckConcent(Action action)
     {
            if (IsConsented())
            {
                 action();
            }
            else
            {
                MessageBox.Show("Need consent first.");
            }
     }
