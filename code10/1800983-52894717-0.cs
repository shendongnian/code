    using System.Linq;
    using UnityEngine;
    private void sortfirendlist()
    {
        GameObject[] Friendcolumns = GameObject.FindGameObjectsWithTag("Friendcolumn");
        // Use linq to get the Objects with and without Rank (not starting / starting with "F")
        GameObject[] withoutRank = Friendcolumns.Where(obj => obj.name.StartsWith("F")).ToArray();
        GameObject[] withRank = Friendcolumns.Where(obj => !obj.name.StartsWith("F")).ToArray();
        // Sort the ranked by name (again using Linq)
        GameObject[] rankedSorted = withRank.OrderBy(go => go.name).ToArray();
        // Now we have our ordered arrays -> we just have to apply that to the scene
        // set sibling index for the ranked 
        foreach (var t in rankedSorted)
        {
            // I simply send them one by one to the bottom
            // => when we are finished they are all sorted at the bottom
            t.transform.SetAsLastSibling();
        }
        // Do the same for the unreanked to also send them to the bottom
        foreach (var t in withoutRank)
        {
            t.transform.SetAsLastSibling();
        }
        // Now the object we sent to the bottom first 
        // (first element in withRank) should be on top and everything sorted below it
    }
