  Dim retval As Boolean = True
  Dim Itm As System.Configuration.KeyValueConfigurationElement = _
        Config.AppSettings.Settings.Item(TheKey)
  If Itm Is Nothing Then
     If Config.AppSettings.Settings.IsReadOnly Then
        retval = False
     Else
        Config.AppSettings.Settings.Add(TheKey, TheValue)
     End If
  Else
     ' config.AppSettings.Settings(thekey).Value = thevalue
     If Itm.IsReadOnly Then
        retval = False
     Else
        Itm.Value = TheValue
     End If
  End If
  If retval Then
     Try
        Config.Save(ConfigurationSaveMode.Modified)
     Catch ex As Exception
        retval = False
     End Try
  End If
  Return retval
