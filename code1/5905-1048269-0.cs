      Enum appThemes
            Aero
            Luna
            LunaMettalic
            LunaHomestead
            Royale
        End Enum
    
    Private Sub Application_Startup(ByVal sender As Object, ByVal e As System.Windows.StartupEventArgs) Handles Me.Startup
    
            setTheme(appThemes.Aero)
    
        End Sub
    
        ''' <summary>
        ''' Function to set the default theme of this application
        ''' </summary>
        ''' <param name="Theme">
        ''' Theme of type appThemes
        ''' </param>
        ''' <remarks></remarks>
        Public Sub setTheme(ByVal Theme As appThemes)
    
            Dim uri As Uri
    
            Select Case Theme
                Case appThemes.Aero
                    ' Vista Aero Theme
                    uri = New Uri("PresentationFramework.Aero;V3.0.0.0;31bf3856ad364e35;component\\themes/Aero.NormalColor.xaml", UriKind.Relative)
    
                Case appThemes.Luna
                    ' Luna Theme
                    uri = New Uri("PresentationFramework.Luna;V3.0.0.0;31bf3856ad364e35;component\\themes/Luna.NormalColor.xaml", UriKind.Relative)
    
                Case appThemes.LunaHomestead
                    ' Luna Mettalic
                    uri = New Uri("PresentationFramework.Luna;V3.0.0.0;31bf3856ad364e35;component\\themes/Luna.Metallic.xaml", UriKind.Relative)
    
                Case appThemes.LunaMettalic
                    ' Luna Homestead
                    uri = New Uri("PresentationFramework.Luna;V3.0.0.0;31bf3856ad364e35;component\\themes/Luna.Homestead.xaml", UriKind.Relative)
    
                Case appThemes.Royale
                    ' Royale Theme
                    uri = New Uri("PresentationFramework.Royale;V3.0.0.0;31bf3856ad364e35;component\\themes/Royale.NormalColor.xaml", UriKind.Relative)
    
            End Select
    
            ' Set the Theme
            Resources.MergedDictionaries.Add(Application.LoadComponent(uri))
    
        End Sub
