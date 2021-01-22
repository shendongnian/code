    interface IDictionary<string, string> with
        member this.Add(key: string, value : string) = dictionary.Add(key.ToUpper(), value)
        member this.Add(kvp) = dictionary.Add(kvp.Key.ToUpper(), kvp.Value)
        member this.ContainsKey(key) = dictionary.ContainsKey(key.ToUpper())
        member this.Contains(kvp) = dictionary.TryGetValue(kvp.Key.ToUpper(), ref kvp.Value)
        member this.Item with get key = dictionary.Item(key) and set key value = dictionary.Item(key) <- value
        member this.Count with get() = dictionary.Count
        member this.IsReadOnly with get() = false
        member this.Keys = dictionary.Keys :> ICollection<String>
        member this.Remove key = dictionary.Remove(key)
        member this.Remove(kvp : KeyValuePair<String,String>) = dictionary.Remove(kvp.Key.ToUpper())
        member this.TryGetValue(key, value) = dictionary.TryGetValue(key, ref value)
        member this.Values = dictionary.Values :> ICollection<String>
        member this.Clear() = dictionary.Clear()
        member this.CopyTo(array, arrayIndex) = (dictionary.Keys :> ICollection<String>).CopyTo(Array.empty, arrayIndex)
        member this.GetEnumerator() = dictionary.GetEnumerator() :> IEnumerator
        member this.GetEnumerator() = dictionary.GetEnumerator() :> IEnumerator<KeyValuePair<String,String>>
