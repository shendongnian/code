    <Application x:Class="ScenarioEditor.App"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 Startup="Application_Startup"
             >
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary  Source="pack://application:,,,/UILib;component/Resources/Geometries.xaml"/>
                <ResourceDictionary  Source="pack://application:,,,/UILib;component/Resources/ControlTemplates.xaml"/>
                <ResourceDictionary  Source="pack://application:,,,/UILib;component/Resources/FontResources.xaml"/>
                <ResourceDictionary  Source="/Resources/ScenarioEditorResources.xaml"/>
                <ResourceDictionary  Source="pack://application:,,,/UILib;component/Resources/UILibResources.xaml"/>
                <ResourceDictionary  Source="pack://application:,,,/UILib;component/Resources/HypsoColoursRD.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
