    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using System.Windows.Threading;
    using System.ComponentModel;
    
    namespace SilverlightApplication13
    {
        public partial class MainPage : UserControl
        {
            public MainPage()
            {
                InitializeComponent();
    
                //Default
                (this.Resources["TranslationHelper"] as TranslationHelper).SetLanguage("en-US");
            }
    
            private void BtnEnglish_Click(object sender, RoutedEventArgs e)
            {
                (this.Resources["TranslationHelper"] as TranslationHelper).SetLanguage("en-US");
            }
    
            private void BtnSwedish_Click(object sender, RoutedEventArgs e)
            {
                (this.Resources["TranslationHelper"] as TranslationHelper).SetLanguage("sv-SE");
            }
        }
    
        public class TranslationHelper : INotifyPropertyChanged
        {
            private string _Contact;
    
            /// <summary>
            /// Contact Property
            /// </summary>
            public string Contact
            {
                get { return _Contact; }
                set
                {
                    _Contact = value;
                    OnPropertyChanged("Contact");
                }
            }
    
            private string _Links;
    
            /// <summary>
            /// Links Property
            /// </summary>
            public string Links
            {
                get { return _Links; }
                set
                {
                    _Links = value;
                    OnPropertyChanged("Links");
                }
            }
    
            private string _Home;
    
            /// <summary>
            /// Home Property
            /// </summary>
            public string Home
            {
                get { return _Home; }
                set
                {
                    _Home = value;
                    OnPropertyChanged("Home");
                }
            }
    
    
    
            public TranslationHelper()
            {
                //Default
                SetLanguage("en-US");
            }
    
            public void SetLanguage(string cultureName)
            {
                //Hard coded values, need to be loaded from db or elsewhere
    
                switch (cultureName)
                {
                    case "sv-SE":
                        Contact = "Kontakt";
                        Links = "Länkar";
                        Home = "Hem";
                        break;
    
                    case "en-US":
                        Contact = "Contact";
                        Links = "Links";
                        Home = "Home";
                        break;
    
                    default:
                        break;
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
