    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    
    namespace WpfApp5.ViewModels
    {
        public class ProductionLineConfigViewModel : INotifyPropertyChanged
        {
            public CustomCommand<ProductionLineConfig> UpdateCommand { get; }
    
            public ProductionLineConfigViewModel()
            {
                PopulateProductionLineConfigs();
                UpdateCommand = new CustomCommand<ProductionLineConfig>(UpdateConfig, (u) => true);
            }
    
            private ObservableCollection<ProductionLineConfig> _listAllProductionLineConfigs;
            public ObservableCollection<ProductionLineConfig> listAllProductionLineConfigs
            {
                get { return _listAllProductionLineConfigs; }
                set
                {
                    _listAllProductionLineConfigs = value;
                    OnPropertyChanged();
                }
            }
    
            //  Call this from constructor.
            private void PopulateProductionLineConfigs()
            {
                listAllProductionLineConfigs = new ObservableCollection<ProductionLineConfig>
                {
                    new ProductionLineConfig
                    {
                        ProductionLineId = 1,
                        ProductionLineCode = "001",
                        ProductionLineCreatedDate = DateTime.Today.Date,
                        ProductionLineName = "safdsf",
                        ProductionLineStatus = true
                    },
                    new ProductionLineConfig
                    {
                        ProductionLineId = 1,
                        ProductionLineCode = "002",
                        ProductionLineCreatedDate = DateTime.Today.Date,
                        ProductionLineName = "sadfadfsdf",
                        ProductionLineStatus = true
                    }
                };
            }
    
            private void UpdateConfig(ProductionLineConfig config)
            {
                MessageBox.Show("Line Name update: " + config.ProductionLineName);
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
        }
    
        public class ProductionLineConfig
        { 
            public int ProductionLineId { get; set; }
    
            public string ProductionLineCode { get; set; }
    
            public string ProductionLineName { get; set; }
    
            public bool ProductionLineStatus { get; set; }
            public DateTime ProductionLineCreatedDate { get; set; }
        }
    }
