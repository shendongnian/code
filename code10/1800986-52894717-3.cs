    using System.Linq;
    using UnityEngine;
    private void sortfirendlist()
    {
        var Friendcolumns = GameObject.FindGameObjectsWithTag("Friendcolumn");
        // Use linq to get the Objects with and without Rank (not starting / starting with "F")
        // This works a bit similar to sql code
        // -> if the "Where" returns true -> object stays in the list
        // using string.StartsWidth which is a 
        // better choice for what you are doing with Substring(0,1)== ...
        var withoutRank = Friendcolumns.Where(obj => obj.name.StartsWith("F"));
        var withRank = Friendcolumns.Where(obj => !obj.name.StartsWith("F"));
        // Sort the ranked by name (again using Linq)
        var rankedSorted = withRank.OrderBy(go => go.name);
        // Now we have our ordered arrays -> we just have to apply that to the scene
        // set sibling index for the ranked 
        foreach (var t in rankedSorted)
        {
            // I simply send them one by one to the bottom
            // => when we are finished they are all sorted at the bottom
            t.transform.SetAsLastSibling();
        }
        // Do the same for the unranked to also send them to the bottom
      
        Debug.Log(withoutRank.Length + " Friends without Rank");
        foreach (var t in withoutRank)
        {
            Debug.Log(t.name + " has no rank");
            t.transform.SetAsLastSibling();
        }
        // Now the object we sent to the bottom first 
        // (first element in withRank) should be on top and everything sorted below it
    }
