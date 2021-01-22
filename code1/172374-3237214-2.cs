    using System.Diagnostics;
    private Unit GetUnit(Unit organisationalUnit, int depth)
    {
        debug.assert(depth < 10, "Reached an unexpected high recursion depth"); 
        if (organisationalUnit.IsMainUnit)
        {
            return organisationalUnit;                
        }
        if (organisationalUnit.Parent == null)
            return null;
        return GetUnit(organisationalUnit.Parent, depth + 1);
    }
    private Unit GetUnit(Unit organisationalUnit)
    {
        return GetUnit(organisationalUnit.Parent, 0);
    }
