    private void UpdateType(List<Type> types)
    {
        for(int index =0; index < types.Count; index++)
        {
              Assembly.Load(types[index].Assembly);
              combat = Activator.CreateInstance(types[index]) as ICombatBehaviour;
               
        }
    }
