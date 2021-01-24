    using EIOBoardMobile.Model;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    namespace EIOBoardMobile.Views
    {
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class BoardUserPage : ContentPage
        {
            public class UserProp
            {
                public string userprop { get; set; }
                public string uservalue { get; set; }
            }
            public ObservableCollection<UserProp> SelectedUserProps { get; set; } = new ObservableCollection<UserProp>();
            public BoardUserPage(MobileBoardUser selectedUser)
            {
                InitializeComponent();
                BindingContext = this;
            
            
                foreach (var prop in selectedUser.GetType().GetProperties())
                {
                    if (prop.GetValue(selectedUser).GetType() == typeof(String))
                    {
                        UserProp NewUserProp = new UserProp
                        {
                            userprop = prop.Name.ToString(),
                            uservalue = prop.GetValue(selectedUser).ToString()
                        };
                        SelectedUserProps.Add(NewUserProp);
                    }
                }
            }
        }
    }
