    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    
    // The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
    
    namespace SOCityGridView
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            //variables to use in XAML x:Bind
            private UserData currentUserData = new UserData();
            public List<string> CityList { get; set; } = new List<string>();
    
            public MainPage()
            {
                //get latest list of cities from the server
                CityList = CityNameManager.GetListOfCitiesFromServer();
    
                //add sample data to show on the page for demo
                List<VisitedCity> sampleUserVisitedCities = new List<VisitedCity>();
                sampleUserVisitedCities.Add(new VisitedCity { CityName = "City1", VisitedDate = DateTime.Parse("2/2/2016") });
                sampleUserVisitedCities.Add(new VisitedCity { CityName = "City2", VisitedDate = DateTime.Parse("2/2/2015") });
                currentUserData.VisitedCities = new ObservableCollection<VisitedCity>(sampleUserVisitedCities);
    
                this.InitializeComponent();
            }
    
            private void myButton_Click(object sender, RoutedEventArgs e)
            {
                currentUserData.VisitedCities.Add(new VisitedCity { CityName = "City1", VisitedDate = DateTime.Now });
            }
        }
    
        public class UserData
        {
            public string FullName { get; set; }
            public ObservableCollection<VisitedCity> VisitedCities { get; set; }
        }
    
        public class VisitedCity
        {
            public string CityName { get; set; }
            public DateTimeOffset VisitedDate { get; set; }
    
        }
    
        public class CityNameManager
        {
            public static List<string> GetListOfCitiesFromServer()
            {
                List<string> listOfCities = new List<string>();
    
                //code will be here to get the latest list from the server. for now we will manually return a list
    
                listOfCities.Add("City1");
                listOfCities.Add("City2");
                listOfCities.Add("City3");
                listOfCities.Add("City4");
                listOfCities.Add("City5");
    
                return listOfCities;
    
            }
        }
    }
