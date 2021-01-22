      Public Shared Function PersistableProperties(Item As System.Type) As IEnumerable(Of System.Reflection.PropertyInfo)
        Return From PropertyInfo In Item.GetProperties()
                         Where PropertyInfo.CanWrite AndAlso (IsPersistable(PropertyInfo.PropertyType))
                         Select PropertyInfo
      End Function
