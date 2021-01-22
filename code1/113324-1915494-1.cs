    public class RecordItem:IEquatable<RecordItem>
    {
    ...
        public override int GetHashCode()
        {
            int i=0;
            if (dict != null)
            {
                foreach (KeyValuePair<string, List<string>> pair in dict)
                    i += pair.Key.GetHashCode();
            }
            i += MachineNr.GetHashCode();
            return i;
        }
        public bool Equals(RecordItem item)
        {
            
            if (MachineNr != item.MachineNr)
                return false;
            else
            {
                if ((dict != null && item.dict == null) || (dict == null && item.dict != null))
                    return false;
                else if (dict != null && item.dict != null)
                {
                    foreach (KeyValuePair<string, List<string>> pair in dict)
                    {
                        if (!item.dict.ContainsKey(pair.Key))
                            return false;
                    }
                    return true;
                }
                else return true;
            }
        }
    }
