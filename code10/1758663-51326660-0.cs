    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
        public abstract class BindableBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
            {
                if (object.Equals(storage, value)) return false;
    
                storage = value;
                this.OnPropertyChanged(propertyName);
                return true;
            }
    
            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var eventHandler = this.PropertyChanged;
                if (eventHandler != null)
                {
                    eventHandler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
        public class MainWindow_VM : BindableBase
        {
            public MainWindow_VM()
            {
                reportTypes.Add(new Config()
                {
                    id = Guid.NewGuid().ToString(),
                    Processors = new Dictionary<string, Processor>() {
                        { "Processor 1", new Processor() { processorType = "Blue" } },
                        { "Processor 2", new Processor() { processorType = "Yellow" } }
                    }
                });
    
                reportTypes.Add(new Config()
                {
                    id = Guid.NewGuid().ToString(),
                    Processors = new Dictionary<string, Processor>() {
                        { "Processor 3", new Processor() { processorType = "Green" } },
                        { "Processor 4", new Processor() { processorType = "Red" } }
                    }
                });
    
                selectedProcessorsView = new ListCollectionView(processors);
                selectedProcessorsView.Filter = processorFilter;
            }
    
            public bool processorFilter(object item)
            {
                bool result = true;
                ProcessorWrapper p = item as ProcessorWrapper;
    
                if (p.isEnabled == false)
                    result = false;
    
                return result;
            }
    
            private Config _selectedConfiguration;
            public Config selectedConfiguration
            {
                get { return _selectedConfiguration; }
                set
                {
                    SetProperty(ref _selectedConfiguration, value);
    
                    processors.Clear();
    
                    foreach (KeyValuePair<string, Processor> kvp in value.Processors)
                        processors.Add(new ProcessorWrapper(kvp.Value, this.selectedProcessorsView));
                }
            }
    
            public ObservableCollection<Config> reportTypes { get; } = new ObservableCollection<Config>();
    
            public ObservableCollection<ProcessorWrapper> processors { get; } = new ObservableCollection<ProcessorWrapper>();
    
            public ListCollectionView selectedProcessorsView { get; set; }
        }
    
        public class ProcessorWrapper : BindableBase
        {
            public ProcessorWrapper(Processor processor, ListCollectionView lcv)
            {
                _processor = processor;
                _lcv = lcv;
            }
    
            private Processor _processor;
            private ListCollectionView _lcv;
    
            private string _processorType;
            public string processorType
            {
                get {
    
                    _processorType = _processor.processorType;
                    return _processorType;
                }
            }
    
            private bool _isEnabled;
            public bool isEnabled
            {
                get {
                    _isEnabled = this._processor.Settings.isEnabled;
                    return _isEnabled; }
                set
                {
                    SetProperty(ref _isEnabled, value);
                    this._processor.Settings.isEnabled = _isEnabled;
                    _lcv.Refresh();
                }
            }
        }
    
    
        /// <summary>
        /// These classes belong to a separate class library, should not be modified.  
        /// </summary>
    
        public class Config
        {
            public string id { get; set; }
            public Dictionary<string, Processor> Processors { get; set; } 
        }
        public class Processor
        {
            public string processorType { get; set; }
            public Settings Settings { get; set; } = new Settings() {
                isEnabled = false
            };
        }
        public class Settings
        {
            public bool isEnabled { get; set; }
        }
    }
