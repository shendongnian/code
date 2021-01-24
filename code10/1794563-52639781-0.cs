    public string ToString(int level = 0, HashSet<int> visited)
    {
            foreach(var child in children)
            {
                    if(visited.Add(child.Id))
                       sb.Append(child.ToString(level + 1, visited));
                    else
                       //Handle the case when a cycle is detected.
            }       
            return sb.ToString();
    }
