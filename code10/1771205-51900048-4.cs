    namespace WpfApp1.ViewModels
    {
        using System;
        using System.Collections.Generic;
        using System.Collections.ObjectModel;
        using System.ComponentModel;
        using System.Linq;
        using System.Runtime.CompilerServices;
        using System.Windows.Controls;
        using System.Windows.Input;
        using WpfApp1.Models;
    
        public class FeatureViewModel : INotifyPropertyChanged
        {
            #region Definitions
    
            #region enum
    
            private enum MyFeatureList
            {
                Layer_1,
                Layer_2,
                Layer_3,
                Layer_4
            }
    
            #endregion enum
    
            #region PrivateProperties
    
            private readonly List<string> features = new List<string>();
    
            #region AddFeatures
    
            private ObservableCollection<Feature> AddFeatures
            {
                get
                {
                    var features = new ObservableCollection<Feature>
                {
                    // add blank feature
                    new Feature("", true)
                };
                    foreach (var feature in Enum.GetNames(typeof(MyFeatureList)))
                    {
                        features.Add(new Feature(feature, true));
                    }
                    return features;
                }
            }
    
            #endregion AddFeatures
    
            #endregion PrivateProperties
    
            #region PublicProperties
    
            public IEnumerable<string> Feature1Items => features.Where(o => o != Feature2SelectedValue && o != Feature3SelectedValue && o != Feature4SelectedValue);
    
            public IEnumerable<string> Feature2Items => features.Where(o => o != Feature1SelectedValue && o != Feature3SelectedValue && o != Feature4SelectedValue);
    
            public IEnumerable<string> Feature3Items => features.Where(o => o != Feature1SelectedValue && o != Feature2SelectedValue && o != Feature4SelectedValue);
    
            public IEnumerable<string> Feature4Items => features.Where(o => o != Feature1SelectedValue && o != Feature2SelectedValue && o != Feature3SelectedValue);
    
            #endregion PublicProperties
    
            #region Constructor
    
            public FeatureViewModel()
            {
                features = AddFeatures.Select(c => c.FeatureName).ToList();
                OnComboBox_ClearSelection = new BaseCommand(ClearSelection);
            }
    
            #endregion Constructor
    
            #region Feature1SelectedValue
    
            protected string feature1SelectedValue;
    
            /// <summary>
            /// Feature 1 selected value
            /// </summary>
            public string Feature1SelectedValue
            {
                get { return feature1SelectedValue; }
                set
                {
                    if (feature1SelectedValue != value)
                    {
                        feature1SelectedValue = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(Feature2Items));
                        OnPropertyChanged(nameof(Feature3Items));
                        OnPropertyChanged(nameof(Feature4Items));
                    }
                }
            }
    
            #endregion Feature1SelectedValue
    
            #region Feature2SelectedValue
    
            protected string feature2SelectedValue;
    
            /// <summary>
            /// Feature 1 selected value
            /// </summary>
            public string Feature2SelectedValue
            {
                get { return feature2SelectedValue; }
                set
                {
                    if (feature2SelectedValue != value)
                    {
                        feature2SelectedValue = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(Feature1Items));
                        OnPropertyChanged(nameof(Feature3Items));
                        OnPropertyChanged(nameof(Feature4Items));
                    }
                }
            }
    
            #endregion Feature2SelectedValue
    
            #region Feature3SelectedValue
    
            protected string feature3SelectedValue;
    
            /// <summary>
            /// Feature 1 selected value
            /// </summary>
            public string Feature3SelectedValue
            {
                get { return feature3SelectedValue; }
                set
                {
                    if (feature3SelectedValue != value)
                    {
                        feature3SelectedValue = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(Feature1Items));
                        OnPropertyChanged(nameof(Feature2Items));
                        OnPropertyChanged(nameof(Feature4Items));
                    }
                }
            }
    
            #endregion Feature3SelectedValue
    
            #region Feature4SelectedValue
    
            protected string feature4SelectedValue;
    
            /// <summary>
            /// Feature 1 selected value
            /// </summary>
            public string Feature4SelectedValue
            {
                get { return feature4SelectedValue; }
                set
                {
                    if (feature4SelectedValue != value)
                    {
                        feature4SelectedValue = value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(Feature1Items));
                        OnPropertyChanged(nameof(Feature2Items));
                        OnPropertyChanged(nameof(Feature3Items));
                    }
                }
            }
    
            #endregion Feature4SelectedValue
    
            #endregion Definitions
    
            #region Methods
    
            public ICommand OnComboBox_ClearSelection { get; }
    
            public void ClearSelection(object sender)
            {
                ComboBox combobox = sender as ComboBox;
                combobox.SelectedItem = null;
            }
    
            #endregion Methods
    
            #region INotifyPropertyChanged Members
    
            /// <summary>
            /// Need to implement this interface in order to get data binding
            /// to work properly.
            /// </summary>
            /// <param name="propertyName"></param>
            private void NotifyPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            #endregion INotifyPropertyChanged Members
        }
    
        #region BaseCommand
    
        public class BaseCommand : ICommand
        {
            private readonly Predicate<object> _canExecute;
            private readonly Action<object> _method;
    
            public event EventHandler CanExecuteChanged;
    
            public BaseCommand(Action<object> method)
                : this(method, null)
            {
            }
    
            public BaseCommand(Action<object> method, Predicate<object> canExecute)
            {
                _method = method;
                _canExecute = canExecute;
            }
    
            public bool CanExecute(object parameter)
            {
                if (_canExecute == null)
                {
                    return true;
                }
    
                return _canExecute(parameter);
            }
    
            public void Execute(object parameter)
            {
                _method.Invoke(parameter);
            }
    
            #endregion BaseCommand
        }
    }
