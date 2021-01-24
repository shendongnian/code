     @Html.DevExpress().GetStyleSheets(
            new StyleSheet { ExtensionSuite = ExtensionSuite.NavigationAndLayout },
            new StyleSheet { ExtensionSuite = ExtensionSuite.Editors, ExtensionType = ExtensionType.Button },
            new StyleSheet { ExtensionSuite = ExtensionSuite.GridView }
    
        )
        @Html.DevExpress().GetScripts(
            new Script { ExtensionSuite = ExtensionSuite.NavigationAndLayout },
            new Script { ExtensionSuite = ExtensionSuite.Editors, ExtensionType = ExtensionType.Button },
            new Script { ExtensionSuite = ExtensionSuite.GridView }
        )
