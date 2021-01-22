    private void clearCollection(Control.ControlCollection target)
        {
            List<Control> accumulator = new List<Control>();
            foreach (Control Actrl in target)
            {
                if (Actrl is Label || Actrl is Button)
                {
                    accumulator.Add(Actrl);  // find all controls first. 
                }
            }
            for (int i = 0; i < accumulator.Count; i++)
            {
                target.Remove(accumulator[i]);
            }
        }
