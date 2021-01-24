        private void GetControlList<T>(ControlCollection controlCollection, List<T> resultCollection)
    where T : Control
        {
            foreach (Control control in controlCollection)
            {
                //if (control.GetType() == typeof(T))
                if (control is T) // This is cleaner
                    resultCollection.Add((T)control);
    
                if (control.HasControls())
                    GetControlList(control.Controls, resultCollection);
            }
        }
