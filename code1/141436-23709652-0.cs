Dim tbl As LuaTable = lua.GetTable("DB.inventory")
For Each item As DictionaryEntry In tbl
  Debug.Print("{0} = {1}", item.Key, item.Value)
  Dim subTbl As LuaTable = item.Value
  For Each subItem As DictionaryEntry in subTbl
    Debug.Print("     {0} = {1}", subItem.Key, subItem.Value)
  Next
Next 
