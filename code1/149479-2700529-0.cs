        foreach (ICollection<IGameObjectController> layerSet in layers.Values)
        {
            foreach (IGameObjectController controller in layerSet
                       .Where(c => c.Model.DefinedInVariant).ToList())
            {
                layerSet.Remove(controller);
                
            }
        }
