    public class Dispatcher
    {
        public void Dispatch(IUnit unit, ITerrain terrain)
        {
            Type unitType = unit.GetType();
            Type terrainType = terrain.GetType();
            // go through the list and find the action that corresponds to the
            // most-derived IUnit and ITerrain types that are in the ancestor
            // chain for unitType and terrainType.
            Action<IUnit, ITerrain> action = /* left as exercise for reader ;) */
            action(unit, terrain);
        }
        // add functions to this
        public List<Action<IUnit, ITerrain>> Actions = new List<Action<IUnit, ITerrain>>();
    }
