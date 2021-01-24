    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    namespace SampleCode
    {
        /// <summary>
        /// A simple example of a view-model.  
        /// </summary>
        public class ViewModel : INotifyPropertyChanged
        {
            #region Data Members
            /// <summary>
            /// The list of rectangles that is displayed in the ListBox.
            /// </summary>
            private ObservableCollection<RectangleViewModel> rectangles = new ObservableCollection<RectangleViewModel>();
            #endregion
            public ViewModel()
            {
                // Populate the view model with some example data.
                var r1 = new RectangleViewModel(0.1,0.3);
                rectangles.Add(r1);
                var r2 = new RectangleViewModel(0.2,0.4);
                rectangles.Add(r2);
            }
            /// <summary>
            /// The list of rectangles that is displayed in the ListBox.
            /// </summary>
            public ObservableCollection<RectangleViewModel> Rectangles
            {
                get
                {
                    return rectangles;
                }
            }
            #region INotifyPropertyChanged Members
            /// <summary>
            /// Raises the 'PropertyChanged' event when the value of a property of the view model has changed.
            /// </summary>
            private void OnPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
            /// <summary>
            /// 'PropertyChanged' event that is raised when the value of a property of the view model has changed.
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;
            #endregion
        }
    }
