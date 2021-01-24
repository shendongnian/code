    private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
    {
       if (Persons.ItemContainerGenerator.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
       {
           int index = Persons.SelectedIndex;
           if (index >= 0)
               ((ListViewItem)Persons.ItemContainerGenerator.ContainerFromIndex(index)).Focus();
       }
    }
