            public void MechanicalPenthouseButtons()
            {
                if(App.Day == "Tue")
                {
                    SignInButtonStatus();
                    AHU1A2B7AButton.Visibility = Visibility.Visible; //Button 1
                    AHU2B3C4D9C10DButton.Visibility = Visibility.Visible; //Button 2
                    AHU4D5E6RButton.Visibility = Visibility.Visible; //Button 3
                    MainPenthouseButton.Visibility = Visibility.Visible; //Button 4
                    CHWPButton.Visibility = Visibility.Visible; //Button 5
                    AHU13A14B15CButton.Visibility = Visibility.Visible; // Button 6
                    AHU15C16D17E21C22DButton.Visibility = Visibility.Visible; // Button 7
                    AHU17E18R24RButton.Visibility = Visibility.Visible; // Button 8
                    AHURoom3020Button.Visibility = Visibility.Visible; // Button 9
                    AHU22D23E24RButton.Visibility = Visibility.Visible; // Button 10
                    AHU19A20B21CButton.Visibility = Visibility.Visible; // Button 11
                    AHU10D11E12RButton.Visibility = Visibility.Visible; //Button 12
                    AHU7A8B9CButton.Visibility = Visibility.Visible; //Button 13
                }
                else
                {
                    SignInButtonStatus();
                    CHWPButton.Visibility = Visibility.Visible; //Button 5
                    CHWPButton.Margin = new Thickness(50, 10, 45, 10); // Was (50,10,0,0)
                    AHURoom3020Button.Visibility = Visibility.Visible; //Button 9
                    AHURoom3020Button.Margin = new Thickness(50, 10, 45, 10); // Was (50,10,0,0)
                }
            }
