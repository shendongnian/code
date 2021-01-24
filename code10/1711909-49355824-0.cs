    //firt change your class commanclass with that code 
    
    using System;
    using System.Collections.Generic;
    
    namespace NewParkingApp
    {
        public class CommonClass
        {
            public static List < string > itemData = new List < string > ()  
                {  
                    "Android",  
                    "IOS",  
                    "Windows Phone",  
                    "Xamarin-IOS",  
                    "Xamarin-Form",  
                    "Xamarin_Android"  
                };  
    
        }
    }
    
    //after class your main class in past 
    using Foundation;
    using System;
    using System.Collections.Generic;
    using UIKit;
    
    namespace NewParkingApp
    {
        public partial class ResultViewController : UIViewController
        {
            public ResultViewController (IntPtr handle) : base (handle)
            {
            }
    
            public override void ViewDidLoad()
            {
                base.ViewDidLoad();
                List<string> itemData = CommonClass.itemData;
                mainListview.Source = new TableViewSource(itemData);  
            }
        enter code here
            public override void DidReceiveMemoryWarning()
            {
                base.DidReceiveMemoryWarning();
                // Release any cached data, images, etc that aren't in use.
            }
        }
    }
     
