    extern alias compression;
    using System;
    using Xamarin.Forms;
    namespace App1
    {
        public partial class MainPage : ContentPage
        {
            public MainPage()
                {
                    InitializeComponent();
                    try {}          
    
                    // To use the netstandard dll ApplicationException
                    catch(global::System.ApplicationException ee1) {}
    
                    // To use the compression dll ApplicationException
                    catch (compress`enter code here`ion::System.ApplicationException ee2)   {}
                 }
          }
    }
