xml
    <ResourceDictionary x:Class="YourNamespace.DataGridStyles"
                x:ClassModifier="public"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
        <Style TargetType="DataGrid">
            <!-- Your DataGrid style definition goes here -->
    
            <!-- Cell style -->
            <Setter Property="CellStyle">
                <Setter.Value>
                    <Style TargetType="DataGridCell">                    
                        <!-- Your DataGrid Cell style definition goes here -->
                        <!-- Single Click Editing -->
                        <EventSetter Event="PreviewMouseLeftButtonDown"
                                 Handler="DataGridCell_PreviewMouseLeftButtonDown" />
                    </Style>
                </Setter.Value>
            </Setter>
        </Style>
    </ResourceDictionary>
Note the x:Class attribute in the root element. 
Create a class file. In this example it'd be *DataGridStyles.xaml.cs*. Put this code inside:
    using System.Windows.Controls;
    using System.Windows;
    using System.Windows.Input;
    
    namespace YourNamespace
    {
        partial class DataGridStyles : ResourceDictionary
        {
    
            public DataGridStyles()
            {
              InitializeComponent();
            }
        
         // The code from the myermian's answer goes here.
    }
