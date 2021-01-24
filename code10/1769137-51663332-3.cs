    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.Windows.Media;
    using System.Windows;
    namespace SampleCode
    {
        /// <summary>
        /// Defines the view-model for a simple displayable rectangle.
        /// </summary>
        public class RectangleViewModel : INotifyPropertyChanged
        {
            #region Data Members
            /// <summary>
            /// The aspect ration of the image
            /// </summary>
            private double ratio = 1.375;
            /// <summary>
            /// The label width
            /// </summary>
            private double mLabelWidth = 20;
            /// <summary>
            /// The X coordinate of the location of the rectangle (in content coordinates).
            /// </summary>
            private double mX;
            /// <summary>
            /// The Y coordinate of the location of the rectangle (in content coordinates).
            /// </summary>
            private double mY;
            /// <summary>
            /// The size of the current window
            /// </summary>
            public Size mCurrentWindwoSize = new Size(450,300);
            /// <summary>
            /// The size of the label as a percantage from the image size
            /// </summary>
            private readonly double sizePercentage = 0.05;
            #endregion Data Members
            public RectangleViewModel(double x, double y)
            {
                mX = x;
                mY = y;
            }
            /// <summary>
            /// The size of the background image
            /// </summary>
            public Size ImageSize { get; set; }
            /// <summary>
            /// The width of the label
            /// </summary>
            public double LabelWidth
            {
                get { return mLabelWidth; }
                set { if (value == mLabelWidth)
                        return;
                    else
                        mLabelWidth = value;
                    OnPropertyChanged("LabelWidth");
                }
            }
            /// <summary>
            /// The X coordinate of the location of the rectangle (in content coordinates).
            /// </summary>
            public double X
            {
                get
                {
                    return (mCurrentWindwoSize.Width-ImageSize.Width)/2 + mX * ImageSize.Width - mLabelWidth/2;
                }
                set
                {
                    //if ((mCurrentWindwoSize.Width - ImageSize.Width) / 2 + mX * ImageSize.Width == value)return;
                    mX =( value - (mCurrentWindwoSize.Width - ImageSize.Width) / 2 + mLabelWidth/2)/ ImageSize.Width;
                    OnPropertyChanged("X");
                }
            }
            /// <summary>
            /// The Y coordinate of the location of the rectangle (in content coordinates).
            /// </summary>
            public double Y
            {
                get
                {
                    return (mCurrentWindwoSize.Height - ImageSize.Height) / 2 + mY * ImageSize.Height - mLabelWidth/2 ;
                }
                set
                {
                    //if ((mCurrentWindwoSize.Height - ImageSize.Height) / 2 + mY * ImageSize.Height == value) return;
                    mY = (value - (mCurrentWindwoSize.Height - ImageSize.Height) / 2 + mLabelWidth/2) / ImageSize.Height;
                    OnPropertyChanged("Y");
                }
            }
            public void update(Size windowSize)
            {
                mCurrentWindwoSize = windowSize;
                if (windowSize.Height > windowSize.Width * ratio)
                {
                    ImageSize = new Size(windowSize.Width, windowSize.Width * ratio);
                }
                else
                {
                    ImageSize = new Size(windowSize.Height / ratio, windowSize.Height);
                }
                LabelWidth = ImageSize.Width * sizePercentage;
                X = (mCurrentWindwoSize.Width - ImageSize.Width) / 2 + mX * ImageSize.Width - mLabelWidth/2;
                Y = (mCurrentWindwoSize.Height - ImageSize.Height) / 2 + mY * ImageSize.Height - mLabelWidth/2;
            }
            #region INotifyPropertyChanged Members
            /// <summary>
            /// Raises the 'PropertyChanged' event when the value of a property of the view model has changed.
            /// </summary>
            protected void OnPropertyChanged(string name)
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
