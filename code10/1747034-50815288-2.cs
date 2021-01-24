    using System.Windows;
    using System.Windows.Controls;
    using Infrastructure.Interfaces;
    using Modules.Interfaces.ImportAssistant;
    using Prism.Regions;
    using Infrastructure;
    using Microsoft.Practices.ServiceLocation;
    using System.Linq;
    
    namespace Modules.View.ImportAssistant
    {
        /// <summary>
        /// Interaction logic for ImportDialogView.xaml
        /// </summary>
        public partial class ImportDialogView : UserControl, IImportDialogView
        {
            public ImportDialogView(IImportDialogViewModel viewModel)
            {
                InitializeComponent();
    
                ViewModel = viewModel;
                viewModel.View = this;
    
                var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
    
                if (regionManager.Regions.Any(r => r.Name == RegionNames.ImportAssistantMain) == false)
                {
                    RegionManager.SetRegionName(AssistantDialogContentControl, RegionNames.ImportAssistantMain);
                    RegionManager.SetRegionManager(AssistantDialogContentControl, regionManager);
                }
            }
    
            public IViewModel ViewModel
            {
                get { return (IImportDialogViewModel)DataContext; }
                set { DataContext = value; }
            }
    
            private void ImportDialogView_OnLoaded(object sender, RoutedEventArgs e)
            {
                
            }
        }
    }
    
