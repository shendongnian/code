    private void ConvertInchesTofeet(ObservableCollection<Model> containerLevels)
    {
       for(int i = 0; i< containerLevels.Count; i++)
       {
       ContainerLevels[i].Level1 = containerLevels[i].Level1 / 12;
       }
    }
