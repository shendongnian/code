    using DLToolkit.Forms.Controls;
    using System;
    using Xamarin.Forms;
    
    namespace FlowListTest
    {
        public partial class MainPage : ContentPage
        {
            public MainPage()
            {
                InitializeComponent();
                LoadUI();
                BindingContext = new BContext();
            }
    
            private void LoadUI()
            {
                var dataTemplate = new DataTemplate(() =>
                {
                    var image = new Image();
                    image.SetBinding(Image.SourceProperty, "BgImage");
    
                    var titleLabel = new Label
                    {
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        TextColor = Color.White,
                    };
                    titleLabel.SetBinding(Label.TextProperty, "Title");
    
                    var subTitleLabel = new Label
                    {
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        TextColor = Color.White,
                    };
                    subTitleLabel.SetBinding(Label.TextProperty, "Subtitle");
    
                    return new StackLayout
                    {
                        BackgroundColor = Color.Pink,
                        Padding = 2,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = {
                            new Frame {
                                Content = new AbsoluteLayout {
                                     HorizontalOptions = LayoutOptions.FillAndExpand,
                                     VerticalOptions = LayoutOptions.FillAndExpand,
                                     Children = {
                                        image,
                                        new StackLayout {
                                             Margin = new Thickness(20),
                                             VerticalOptions = LayoutOptions.CenterAndExpand,
                                             HorizontalOptions = LayoutOptions.CenterAndExpand,
                                             Children = {
                                                titleLabel,
                                                subTitleLabel
                                             }
                                        }
                                     }
                                }
                            }
                        }
                    };
                });
    
                var flowList = new FlowListView();
                flowList.SetBinding(FlowListView.FlowItemsSourceProperty, "List");
                flowList.FlowColumnTemplate = dataTemplate;
                flowList.BackgroundColor = Color.LightGoldenrodYellow;
                flowList.FlowColumnCount = 1;
                flowList.HasUnevenRows = true;
                
                var button = new Button { Text = "Add" };
                button.Clicked += Button_Clicked
                ;
                Content = new StackLayout
                {
                    Children = {
                        button,
                        flowList
                    }
                };
    
            }
    
            private void Button_Clicked(object sender, EventArgs e)
            {
                (BindingContext as BContext).Add();
            }
        }
    
        public class Foo
        {
            public string BgImage { get; set; }
            public string Title { get; set; }
            public string Subtitle { get; set; }
        }
    
        public class BContext
        {
            public FlowObservableCollection<Foo> List { get; set; }
    
            public BContext()
            {
                List = new FlowObservableCollection<Foo>
                {
                    new Foo {
                        BgImage = "http://via.placeholder.com/350x150",
                        Title = "Title",
                        Subtitle = "SubTitle"
                    },
                    new Foo {
                        BgImage = "http://via.placeholder.com/350x150",
                        Title = "Title1",
                        Subtitle = "SubTitle1"
                    }
                };
            }
    
            public void Add()
            {
                List.Add(new Foo
                {
                    BgImage = "http://via.placeholder.com/350x150",
                    Title = "Title" + List.Count,
                    Subtitle = "SubTitle" + List.Count
                });
            }
        }
    }
