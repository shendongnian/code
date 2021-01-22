        private readonly IDictionary<float, ICollection<IGameObjectController>> layers;
        
        foreach (ICollection<IGameObjectController> layerSet in layers.Values)
        {
            List<IGameObjectController> toDelete = layerSet.Where(ls => ls.Model.DefinedInVariant).ToList();
            foreach (IGameObjectController controller in toDelete)
            {
               layerSet.Remove(controller);
            }
        }
